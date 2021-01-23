    class Program
    {
        static void Main(string[] args)
        {
            var guids = new HashSet<string>();
            var sw = Stopwatch.StartNew();
            
            while(true)
            {
                var guid = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 16);
                if (guids.Contains(guid)) break;
                guids.Add(guid);
            }
            Console.WriteLine("Duplicate found in {0} ms, after {1} items.", sw.ElapsedMilliseconds, guids.Count);
            Console.ReadLine();
        }
    }
