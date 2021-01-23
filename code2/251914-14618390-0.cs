    using System;
    using System.Collections.Generic;
    using System.Text;
    
    namespace Star_Pyramid
    {
        class Program
        {
            static void Main(string[] args)
            {
                Program o = new Program();
                o.show();
    
                Console.ReadKey();
            }
            void show()
            {
               for (int i = 1; i <= 12; i++)
                {
                    for (int j = 1; j <= 9 - i / 2; j++)
                    {
                        Console.Write("   ");
                    }
                    for (int k = 1; k <= i; k++)
                    {
                        Console.Write(" * ");
                        Console.Write(" ");
                        
    
                    }
                    Console.WriteLine();
    
                }
            }
        }
    }
