using System;
namespace CSharpConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello User what is your name?");
            string name = Console.ReadLine();
            Console.WriteLine("Hello " + name + " Please enter in a number");
            string useint1 = Console.ReadLine();
            Console.WriteLine("Please enter a Math Operator: +, -, *, / ");
            string equation = IsValidSymbol();
            Console.WriteLine($"You equation symbol: {equation}");
            Console.WriteLine("Please  enter another number");
            string useint2 = Console.ReadLine();
            double result = MathSymbols(equation,useint1,useint2);
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
        private static double MathSymbols(string e, string useint1,string useint2)
        {
            double result = 0;
            double userinput1;
            double userinput2;
            while (!double.TryParse(useint1, out userinput1))
            {
                Console.WriteLine("please type in a number");
                useint1 = Console.ReadLine();
            }
            while (!double.TryParse(useint2, out userinput2))
            {
                Console.WriteLine("please type in a number");
                useint1 = Console.ReadLine();
            }
            if (e == "+")
            {
                result = userinput1 + userinput2;
            }
            else if (e == "-")
            {
                result = userinput1 - userinput2;
            }
            else if (e == "*")
            {
                result = (userinput1 * userinput2);
            }
            else if (e == "/")
            {
                result = (userinput1 / userinput2);
            }
            return result;
        }
    }
}
