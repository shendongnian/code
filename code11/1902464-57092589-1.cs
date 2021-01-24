    class Program
    {
        static void Main()
        {
            var dicts = new IDictionary[] {
                new Dictionary<string, int>()       {   { "aa", 1   },  { "bb", 2   }   },
                new Dictionary<string, double>()    {                   { "bb", 2.0 }   },
                new Dictionary<string, int>()       {   { "aa", 0   }                   },
                new Dictionary<string, double>()    {   { "aa", 5.0 },  { "bb", 7.0 }   },
            };
            var keys = dicts.SelectMany(d => d.Keys as IEnumerable<object>).Distinct();
            foreach (var p in keys.Select(k => (k, vals: dicts.Select(d => d[k]))))
            {
                Console.WriteLine(p.k + "\t" + string.Join("\t", p.vals));
            }
            Console.ReadLine();
        }
    }
