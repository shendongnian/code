        int start = 0;
        int end = 1000;
        int divisible = 5;
        var list = System.Linq.Enumerable.Range(start, (end / divisible)+1)
                                         .Select(i => i * divisible);
        foreach (var item in list)
        {
            Console.WriteLine (item);
        }
