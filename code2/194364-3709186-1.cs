    foreach (int? i in list)
    {
        if (i.HasValue)
        {
            Console.WriteLine(i.GetType());
        }
    }
    foreach (int? CS$0$0000 in list)
    {
        Console.WriteLine(CS$0$0000.Value.GetType());
    }
