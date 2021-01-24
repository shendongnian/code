    static void Main(string[] args)
    {
        var list = new List<string>
        {
            "1",
            "23",
            "456",
            "7890",
            "23457"
        };
        var prefixFound = false;
        foreach (var num in list)
        {
            if (list.Any(x => x.StartsWith(num) && x != num))
            {
                prefixFound = true;
                Console.WriteLine(num);
                break;
            }
        }
        if (!prefixFound)
            Console.WriteLine("Consistent list.");
        Console.ReadLine();
    }
