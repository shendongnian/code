    Dictionary<int, int> dict = new Dictionary<int, int>();
    dict[0] = 2;
    dict[1] = 3;
    foreach (var item in dict.OrderByDescending(key => key.Value))
    {
        Console.WriteLine(item.Key);
        Console.WriteLine(item.Value);
    } 
