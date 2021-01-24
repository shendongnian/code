    using System;
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string firstLetter = "KLMN";
                int firstLength = firstLetter.Length;
                int i = 0;
                string PostalCode = "N2L0G6";
                while (i < firstLength)
                {
                    if (PostalCode.Contains(firstLetter[i]))
                    {
                        Console.WriteLine(firstLetter[i] + " found in " + PostalCode);
                    }
                    else
                    {
                        Console.WriteLine(firstLetter[i] + " not found in " + PostalCode);
                    }
                    i++;
                }
                Console.Read();
            }
        }
    }
