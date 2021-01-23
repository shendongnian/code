    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace Server
    {
        class Program
        {
            static void Main(string[] args)
            {
                var i = 0;
                while(true)
                {
                    Console.WriteLine(Console.ReadLine() + " -> " + i++);
                }
            }
        }
    }
