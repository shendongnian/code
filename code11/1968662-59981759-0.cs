using System;
namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            int Test = Console.ReadLine();
            Console.WriteLine(Test);
        }
    }
} 
Since 13 is key code for enter, you are probably getting that number from trying to read the whole line.
