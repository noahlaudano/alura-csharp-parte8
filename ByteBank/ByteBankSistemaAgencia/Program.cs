﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ByteBank.ByteBankModelos;
using ByteBank.ByteBankModelos.Funcionarios;
using ByteBank.ByteBankSistemaAgencia.Comparadores;
using ByteBank.ByteBankSistemaAgencia.Extensoes;

namespace ByteBank.ByteBankSistemaAgencia
{
    class Program
    {
        static void Main(string[] args)
        {
            var idades = new List<int>();
            idades.AdicionarVarios(1, 5, 14, 25, 38, 61);

            idades.Sort();

            foreach (var idade in idades)
            {
                Console.WriteLine(idade);
            }

            var nomes = new List<string>()
            {
                "Vinícius",
                "Gisele",
                "Mayra",
                "Vasco"
            };

            nomes.Sort();

            foreach (var nome in nomes)
            {
                Console.WriteLine(nome);
            }

            var contas = new List<ContaCorrente>()
            {
                new ContaCorrente(341, 57480),
                new ContaCorrente(342, 45678),
                new ContaCorrente(340, 1),
                new ContaCorrente(340, 99999),
                new ContaCorrente(340, 48950),
                new ContaCorrente(290, 18950)
            };

            // contas.Sort(); ~~> Chamar a implementação dada em IComparable

            // contas.Sort(new ComparadorContaCorrentePorAgencia());

            // contas.OrderBy(conta => conta.Numero);
            // foreach (var conta in contas)
            // {
            //     Console.WriteLine($"Conta número {conta.Numero}, ag. {conta.Agencia}");
            // }

            var contasOrdenadas = contas.OrderBy(conta =>
                {
                    if (conta == null)
                    {
                        return int.MaxValue;
                    }
                    return conta.Numero;
                });

            foreach (var conta in contasOrdenadas)
            {
                if (conta != null)
                {
                    Console.WriteLine($"Conta número {conta.Numero}, ag. {conta.Agencia}");
                }
            }

            // var contasNaoNulas = contas.Where(conta => conta != null);
            // var contasOrdenadas = contasNaoNulas.OrderBy(conta => conta.Numero);
            // o método Where retorna o tipo IEnumerable<T> - o mesmo tipo usado pelo método de extensão OrderBy. Então podemos encadear nossas chamadas:
            var contasOrdenadas = contas
                .Where(conta => conta != null)
                .OrderBy(conta => conta.Numero);

            Console.ReadLine();
        }
        static void TestaAdicionarComListExtensoes()
        {
            List<int> idades = new List<int>();

            idades.Add(1);
            idades.Add(5);
            idades.Add(14);
            idades.Add(25);
            idades.Add(38);
            idades.Add(61);

            // ListExtensoes.AdicionarVarios(idades, 1, 5687, 1987, 1567, 987);

            idades.AdicionarVarios(5, 448, 7898, 4564);

            // idades.Remove(5);

            for (int i = 0; i < idades.Count; i++)
            {
                Console.WriteLine(idades[i]);
            }

        }

        static void TestaListaDeObject()
        {
            ListaDeObject listaDeIdades = new ListaDeObject();

            listaDeIdades.Adicionar(10);
            listaDeIdades.Adicionar(5);
            listaDeIdades.Adicionar(4);
            listaDeIdades.Adicionar("um texto qualquer");
            listaDeIdades.AdicionarVarios(16, 23, 60);

            for (int i = 0; i < listaDeIdades.Tamanho; i++)
            {
                int idade = (int)listaDeIdades[i];
                Console.WriteLine($"Idade no indice {i}: {idade}");
            }
        }

        static int SomarVarios(params int[] numeros)
        {
            int acumulador = 0;
            foreach (int numero in numeros)
            {
                acumulador += numero;
            }
            return acumulador;
        }


        static void TestaListaDeContaCorrente()
        {
            //ListaDeContaCorrente lista = new ListaDeContaCorrente();
            ListaDeContaCorrente lista = new ListaDeContaCorrente();

            ContaCorrente contaDoGui = new ContaCorrente(11111, 1111111);

            ContaCorrente[] contas = new ContaCorrente[]
            {
                contaDoGui,
                new ContaCorrente(874, 5679787),
                new ContaCorrente(874, 5679754)
            };

            lista.AdicionarVarios(contas);

            lista.AdicionarVarios(
                contaDoGui,
                new ContaCorrente(874, 5679787),
                new ContaCorrente(874, 5679787),
                new ContaCorrente(874, 5679787),
                new ContaCorrente(874, 5679787),
                new ContaCorrente(874, 5679787),
                new ContaCorrente(874, 5679787),
                new ContaCorrente(874, 5679787),
                new ContaCorrente(874, 5679787)
            );

            for (int i = 0; i < lista.Tamanho; i++)
            {
                ContaCorrente itemAtual = lista[i];
                Console.WriteLine($"Item na posição {i} = Conta {itemAtual.Numero}/{itemAtual.Agencia}");
            }
        }



        static void TestaArrayDeContaCorrente()
        {
            ContaCorrente[] contas = new ContaCorrente[]
                {
                    new ContaCorrente(874, 5679787),
                    new ContaCorrente(874, 4456668),
                    new ContaCorrente(874, 7781438)
                };

            for (int indice = 0; indice < contas.Length; indice++)
            {
                ContaCorrente contaAtual = contas[indice];
                Console.WriteLine($"Conta {indice} {contaAtual.Numero}");
            }
        }

        static void TestaArrayInt()
        {
            // ARRAY de inteiros, com 5 posições!
            int[] idades = null;
            idades = new int[3];

            idades[0] = 15;
            idades[1] = 28;
            idades[2] = 35;
            //idades[3] = 50;
            //idades[4] = 28;
            //idades[5] = 60;

            Console.WriteLine(idades.Length);

            int acumulador = 0;
            for (int indice = 0; indice < idades.Length; indice++)
            {
                int idade = idades[indice];

                Console.WriteLine($"Acessando o array idades no índice {indice}");
                Console.WriteLine($"Valor de idades[{indice}] = {idade}");

                acumulador += idade;
            }

            int media = acumulador / idades.Length;
            Console.WriteLine($"Média de idades = {media}");
        }

    }
}
