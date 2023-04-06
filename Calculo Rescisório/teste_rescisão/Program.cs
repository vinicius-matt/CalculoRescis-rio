using System;

namespace CalculoRescisao
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Cálculo de rescisão trabalhista");

            // Obtenção das informações do funcionário
            Console.Write("Nome do funcionário: ");
            string nome = Console.ReadLine();

            Console.Write("Data de admissão (dd/MM/yyyy): ");
            DateTime dataAdmissao = DateTime.Parse(Console.ReadLine());

            Console.Write("Data de demissão (dd/MM/yyyy): ");
            DateTime dataDemissao = DateTime.Parse(Console.ReadLine());

            Console.Write("Salário base: R$");
            decimal salarioBase = decimal.Parse(Console.ReadLine());

            Console.Write("Valor das férias vencidas: R$");
            decimal valorFeriasVencidas = decimal.Parse(Console.ReadLine());

            Console.Write("Valor do terço de férias: R$");
            decimal valorTercoFerias = decimal.Parse(Console.ReadLine());

            // Cálculos
            int mesesTrabalhados = (dataDemissao.Month - dataAdmissao.Month) + 12 * (dataDemissao.Year - dataAdmissao.Year);
            decimal salarioProporcional = salarioBase / DateTime.DaysInMonth(dataAdmissao.Year, dataAdmissao.Month) * (DateTime.DaysInMonth(dataAdmissao.Year, dataAdmissao.Month) - dataAdmissao.Day + 1);
            decimal decimoTerceiroProporcional = mesesTrabalhados < 12 ? salarioBase / 12 * mesesTrabalhados : salarioBase;
            decimal valorMultaFgts = salarioProporcional * 0.4M;
            decimal valorTotalRescisao = salarioProporcional + valorFeriasVencidas + valorTercoFerias + decimoTerceiroProporcional + valorMultaFgts;

            // Exibição dos resultados
            Console.WriteLine();
            Console.WriteLine($"Funcionário: {nome}");
            Console.WriteLine($"Salário proporcional: R${salarioProporcional:0.00}");
            Console.WriteLine($"Valor de férias vencidas: R${valorFeriasVencidas:0.00}");
            Console.WriteLine($"Valor do terço de férias: R${valorTercoFerias:0.00}");
            Console.WriteLine($"Valor do décimo terceiro proporcional: R${decimoTerceiroProporcional:0.00}");
            Console.WriteLine($"Valor da multa do FGTS: R${valorMultaFgts:0.00}");
            Console.WriteLine($"Valor total da rescisão: R${valorTotalRescisao:0.00}");

            Console.ReadLine();
        }
    }
}
