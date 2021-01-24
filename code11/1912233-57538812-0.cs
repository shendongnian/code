    static void Main(string[] args)
    {
        IList<string> values = new List<string> { "abc", "def", "ghi", "jkl", "mno" };
        IList<double> sort = new List<double> { 3.4, 5.6, -2.4, 7.5, 1.3 };
        IList<string> sortedValues = values
            .Zip(sort, (v, s) => new {v, s}) // combine...
            .OrderBy(it => it.s)             //           ...sort...
            .Select(it => it.v)              //                     ...extract
            .ToList();
        Console.WriteLine(string.Join(", ", values));
        Console.WriteLine(string.Join(", ", sort));
        Console.WriteLine(string.Join(", ", sortedValues));
    }
