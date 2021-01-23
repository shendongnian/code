using System;
namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string x = @"This is a test
                of the emergency
                broadcasting system.".StripLeadingWhitespace();
            Console.WriteLine(x);
            Console.ReadKey();
        }
    }
}
