    using System;
    using System.Collections.Generic;
    class Program
    {
        // declare your variable
        private static Dictionary<string, string> zipLookup;
        public static void CreateZips()
        {
            zipLookup = new Dictionary<string, string>();
            zipLookup.Add("90210", "Beverly Hills");
            // fill all other values, probably from a db
        }
        static void Main(string[] args)
        {
            CreateZips();
            var test  = "90210";
            if (zipLookup.ContainsKey(test))
            {
                Console.WriteLine(test.ToString() + "=" + zipLookup[test]);
            }
            else
            {
                Console.WriteLine(test.ToString() + " location unknown");
            }
        }
    }
