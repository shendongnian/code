    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    namespace ConsoleApplication104
    {
        class Program
        {
            static void Main(string[] args)
            {
                int max = (int)Math.Pow(3,6);
                int size = 50;
                List<List<string>> numbers = CountModThree(max,size);
                Print(numbers);
                Console.ReadLine();
     
            }
            static List<List<string>> CountModThree(int max,int size)
            {
                List<List<string>> results = new List<List<string>>();
                for (int i = 0; i < max; i++)
                {
                    int number = i;
                    List<string> newMod3 = new List<string>();
                    do
                    {
                        int remainder = number % 3;
                        newMod3.Insert(0, remainder.ToString());
                        number = number / 3;
                    } while (number > 0); 
                    int length = newMod3.Select(x => x == "0" ? 8 : x == "1" ? 10 : 12).Sum();
                    if(length <= size) results.Add(newMod3);
                }
                return results;
            }
            static void Print(List<List<string>> numbers)
            {
                foreach(List<string> number in numbers)
                {
                    Console.WriteLine("string : '{0}', Total Length : '{1}, Number 8ft sections : '{2}', Number 10ft sections : '{3}', Number 12ft sections : '{4}'",
                        string.Join("", number),
                        number.Select(x => x == "0" ? 8 : x == "1" ? 10 : 12).Sum(),
                        number.Where(x => x == "0").Count(),
                        number.Where(x => x == "1").Count(),
                        number.Where(x => x == "2").Count()
                        );
                }
            }
        }
    }
