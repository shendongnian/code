using System;
namespace CalculatorExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello User what is your name?");
            string name = Console.ReadLine();
            Console.WriteLine("Hello " + name + " Please enter in a number");
            double useint1 = Validation();
            Console.WriteLine("Please enter a Math Operator: +, -, *, / ");
            string equation = IsValidSymbol();
            Console.WriteLine($"You equation symbol: {equation}");
            Console.WriteLine("Please  enter another number");
            double useint2 = Validation();
            double result = MathSymbols(equation, useint1, useint2);
            Console.WriteLine($"Result: {result}");
            Console.ReadKey();
        }
        public static double Validation()
        {
            string numbString = Console.ReadLine();
            double numbVerify;
            while (!double.TryParse(numbString, out numbVerify))
            {
                Console.WriteLine("please only enter in numbers and do not leave blank");
                numbString = Console.ReadLine();
            }
            return numbVerify;
        }
        private static string IsValidSymbol()
        {
            string mathValidation = Console.ReadLine();
            while ((String.IsNullOrEmpty(mathValidation)))
            {
                Console.WriteLine("Please, do not leave the sentence field empty!");
                Console.WriteLine("Enter a Math Operator: +, -, *, / ");
                mathValidation = Console.ReadLine();
            }
            return mathValidation;
        }
        private static double MathSymbols(string equation, double useint1, double useint2)
        {
            if (equation == "+")
               return useint1 + useint2;
            if (equation == "-")
               return useint1 - useint2;
            if (equation == "*")
                return useint1 * useint2;
            if (equation == "/")
                return useint1 / useint2;
            throw new InvalidOperationException($"Unrecognized equation symbol: {equation}");
        }
    }
}
