    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                String s;
                while ((s = Console.In.ReadLine())!= null)
                {
                    Console.Out.WriteLine(s);
                }
            }
        }
    }
