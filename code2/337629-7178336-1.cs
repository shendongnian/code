using System;
namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string x = @"This is a test
                of the emergency
                broadcasting system.";
            Console.WriteLine(x);
            Console.WriteLine();
            Console.WriteLine("---");
            Console.WriteLine();
            Console.WriteLine(x.StripLeadingWhitespace());
            Console.ReadKey();
        }
    }
}
