    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace ConsoleApp8
    {
        class Program
        {
            static void Main(string[] args)
            {
                var dict = new Dictionary<char, char>()
                {
                    ['A'] = 'T',
                    ['T'] = 'A',
                    ['G'] = 'C',
                    ['C'] = 'G',
                };
    
                var input = "AAGCT";
                var output = string.Concat(input.Select(c => dict[c]).Reverse()); // AGCTT
    
                Console.WriteLine(input);
                Console.WriteLine(output);
            }
        }
    }
