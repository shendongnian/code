    static void Main(string[] args)
    {
        var list = new List<string>();
        var hash = new HashSet<string>();
        for (int i = 0; i < 1000; i++)
        {
            list.Add(i.ToString());
            hash.Add(i.ToString());
        }
        Stopwatch sw = new Stopwatch();
        for (int j = 0; j < 10; j++)
        {
            sw.Start();
            bool isFound1 = list.Contains("999");
            sw.Stop();
            var time1 = sw.Elapsed;
            sw.Reset();
            sw.Start();
            bool isFound2 = hash.Contains("999");
            sw.Stop();
            var time2 = sw.Elapsed;
            sw.Reset();
            Console.WriteLine("list time: " + time1.Ticks);
            Console.WriteLine("hash time: " + time2.Ticks);
            Console.WriteLine();
        }
    }
