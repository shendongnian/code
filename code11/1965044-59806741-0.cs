        private static void TestHashSet(int min, int max, int quantity)
        {
            var gen = new HashSet<int>();
            Random rnd = new Random();
            while (gen.Count < quantity)
            { 
                var temp = rnd.Next(min, max);
                gen.Add(temp);
            }
            gen.AsEnumerable().OrderBy(s => s).ToList().ForEach(x => Console.WriteLine(x));
        }
