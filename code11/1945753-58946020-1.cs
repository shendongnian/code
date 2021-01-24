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
                    if (PostalCode[0].ToString().Contains(firstLetter[i]))
                    {
                        Console.WriteLine(firstLetter[i] + " matches first letter of " + PostalCode);
                    }
                    else
                    {
                        Console.WriteLine(firstLetter[i] + " does not match the first letter of " + PostalCode);
                    }
                    i++;
                }
                Console.Read();
    
            }
        }
    }
