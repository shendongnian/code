    static void Main(string[] args)
    {
        int[] nums = { 20, 15, 31, 34, 35, 40, 50, 90, 99, 100 };
        // here we go
        var items = nums.ToLookup(k => k, k => nums.Where(n => n < k))
            .Select(k => new KeyValuePair<int, double>
                (k.Key, 100 * ((double)k.First().Count() / (double)nums.Length)));
        foreach (var item in items)
        {
            Console.WriteLine("{0}", item);
        }
        Console.Read();
    }
