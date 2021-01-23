    using System;
    using System.Text;
    
    namespace ConsoleApplication8
    {
        class Program
        {
            static void Main(string[] args)
            {
                try
                {
                    Console.WriteLine("Hello From Delphi 2007.Net");
                }
                catch (System.Exception E)
                {
                    Console.WriteLine(E.Message);
                }
            }
        }
    }
