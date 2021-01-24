    using System;
    
    namespace coreconsoleparam
    {
        class Program
        {
            static void Main(string[] args)
            {
                if (args.Length > 0)
                {
                    Console.WriteLine("agrs received :");
                    foreach (string arg in args) {
                        Console.WriteLine(arg+ " ");
                    }
                }
                else {
                    Console.WriteLine("received no args");
                }
            }
        }
    }
