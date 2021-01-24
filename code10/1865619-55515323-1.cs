    var result = Enumerable.Range(1, 100).Select(x => x * 7).ToArray();
    foreach (var item in result)
    {
        Console.WriteLine(item);
    }
    Console.ReadLine();
