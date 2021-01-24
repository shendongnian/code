    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace Linq
    {
        class Program
        {
            static void Main(string[] args)
            {
                IEnumerable<string> listOfStrings = new List<string>()
                {
                    "3.2.31",
                    "5.6.81",
                    "8.0.3521",
                    "25"
                };
    
                var doubleList = listOfStrings.ToList()
                    .Select(y => y.Contains(".") ? 
                        Convert.ToDouble(y.Split(".").FirstOrDefault()) : 
                        Convert.ToDouble(y))
                    .OrderByDescending(x => x);
                
                foreach(var member in doubleList)
                {
                    Console.WriteLine(member);
                }
            }
        }
    }
