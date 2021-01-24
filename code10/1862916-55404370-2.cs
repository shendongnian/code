    var arr = Enumerable.Range(1, 40).ToArray();
    for (int i = 0; i < arr.Length; i++)
    {
        if (i % 4 == 0) { Console.WriteLine("new row"); }
        Console.WriteLine($"row[{i % 4}] = arr[{i}];");
    }
