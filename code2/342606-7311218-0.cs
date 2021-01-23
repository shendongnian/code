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
                while (true)
                {
                    string s;
                    s = Console.ReadLine();
                    int a = Convert.ToInt32(s);
                    a = a / 100;
                    float b = a / (float)10.0;
                    Console.WriteLine(b);
                }
            }
        }
    }
