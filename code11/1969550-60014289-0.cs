    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace ConsoleApp4
    {
    class Program
        {
        static void Main(string[] args)
           {
               {
                Random rand = new Random();
                int[] numbers = new int[4];
                for (int i = 0; i < 4; i++)
                {
                    numbers[i] = rand.Next(1000, 10000);
                }
                string prefix = string.Join("-", numbers);
                string strguid = "";
                for (int i = 0; i < 2; i++)
                {
                    Guid guid = Guid.NewGuid();
                    if (strguid != "")
                    {
                        strguid = strguid + ":" + guid.ToString().Replace("-", "").Substring(0, 26).ToUpper();
                    }
                    else
                    {
                        strguid = guid.ToString().Replace("-", "").Substring(0, 26).ToUpper();
                    }
                    
                }
                Console.WriteLine(strguid);
                Console.ReadKey();
                }
            }
        }
    }
