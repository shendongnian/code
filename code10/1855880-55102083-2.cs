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
                string max = "111111";
                int size = 50;
                List<List<int>> numbers = CountModThree(max,size);
                Print(numbers);
                Console.ReadLine();
     
            }
            static List<List<int>> CountModThree(string max,int size)
            {
                List<List<int>> results = new List<List<int>>();
                List<int> newMod3 = new List<int>() {0};
                while(true)
                {
                    int length = newMod3.Select(x => x == 0 ? 8 : x == 1 ? 10 : 12).Sum();
                    if (length <= size) results.Add(newMod3);
                    if (string.Join("", newMod3) == max) break;
                    newMod3 = AddOne(newMod3);
                }
                return results;
            }
            static List<int> AddOne(List<int> number)
            {
                List<int> newNumber = new List<int>();
                newNumber.AddRange(number);
                int carry = 1;
                for (int i = number.Count - 1; i >= 0; i--)
                {
                    int digit = newNumber[i] + carry;
                    if (digit == 3)
                    {
                        newNumber[i] = 0;
                        carry = 1;
                    }
                    else
                    {
                        newNumber[i] = digit;
                        carry = 0;
                        break;
                    }
                }
                if (carry == 1) newNumber.Insert(0, 0);
                return newNumber;
            }
            static void Print(List<List<int>> numbers)
            {
                foreach(List<int> number in numbers)
                {
                    Console.WriteLine("string : '{0}', Total Length : '{1}, Number 8ft sections : '{2}', Number 10ft sections : '{3}', Number 12ft sections : '{4}'",
                        string.Join("", number),
                        number.Select(x => x == 0 ? 8 : x == 1 ? 10 : 12).Sum(),
                        number.Where(x => x == 0).Count(),
                        number.Where(x => x == 1).Count(),
                        number.Where(x => x == 2).Count()
                        );
                }
            }
        }
    }
