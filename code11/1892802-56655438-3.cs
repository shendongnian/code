    foreach (var result in results)
    {
        Console.WriteLine(result.Key);
        foreach (var item in result.Value)
        {
            Console.WriteLine($" - {item.Key}: {item.Value}");
        }
        Console.WriteLine();
    }
