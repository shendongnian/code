    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace CoreConsole
    {
        public static class Program
        {
            static void Main()
            {
                List<string> stringsList = new List<string> { "people", "desk", "orange", "yellow", "carrot", "pineapple" };
                string search = "pe";
                int n = stringsList.Count(str => 
                    str.Length >= 2
                    && str[ 0] == search[0] 
                    && str[^1] == search[1]);
                Console.WriteLine(n);
            }
        }
    }
