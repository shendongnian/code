    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace Zadatak_2
    {
        class Program
        {
            static void Main(string[] args)
            {
                int broj;
    
                List<int> listaBrojeva = new List<int>();
    
                //Accept only two digits and three digits positive numbers in the list
                do
                {
                    Console.Write("Unesite neki broj: ");
                    int.TryParse(Console.ReadLine(), out broj);
    
                    if (broj >= 10 && broj <= 999)
                    {
                        listaBrojeva.Add(broj);
                    }                
                } while (broj != 0);
    
                Console.WriteLine();
    
                int zeroCounter = 0;
                for (int i = 0; i < listaBrojeva.Count; i++)
                {
                    int number = listaBrojeva[i];
    
                    if (number >= 100 && number <= 999)
                    {
                        ++zeroCounter;
                        Console.Write("0" + "\t");
                    }
                    else Console.Write(number + "\t");
                }
    
                Console.WriteLine("\n\nNumber of 3 digit numbers which are replaced by zero is " + zeroCounter);
            }
        }
    }
