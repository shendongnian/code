    static void Main(string[] args)
    {
        var tests = new List<Guid>();
        for (int i = 0; i < 100000; i++)
        {
            tests.Add(Guid.NewGuid());
        }
        Console.WriteLine("Even: " + tests.Where(g => g.ToByteArray().Last() % 2 == 0).Count());
        Console.WriteLine("Odd : " + tests.Where(g => g.ToByteArray().Last() % 2 == 1).Count());
        Console.ReadKey(true);
    }
