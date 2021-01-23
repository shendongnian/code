    static void Main(string[] args)
    {
        string test = @"abc20a""Hi""""OK""100,20b";
        string[] results = Regex.Split(test, @"(""[a-zA-Z]+""|\d+|[a-zA-Z]+)");
        foreach (string result in results)
        {
            if (!String.IsNullOrEmpty(result) && result != ",")
            {
                Console.WriteLine("result: " + result);
            }
        }
        Console.ReadLine();
    }
