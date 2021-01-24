    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication137
    {
        class Program
        {
            static void Main(string[] args)
            {
                string[] inputs = { "0", "0:a", "0:a:1", "0:1:a:b", "Not valid", "0:a:", "0:a:1:b:" };
                foreach (string input in inputs)
                {
                    string[] splitArray = input.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                    if (splitArray.Length < 2)
                    {
                        Console.WriteLine("Input: '{0}' Not Valid", input);
                    }
                    else
                    {
                        Console.WriteLine("Input: '{0}' First Value : '{1}', Last Value : '{2}'", input, splitArray[0], splitArray[splitArray.Length - 1]);
                    }
                }
                Console.ReadLine();
            }
        }
    }
