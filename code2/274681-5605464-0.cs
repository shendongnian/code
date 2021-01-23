    string operation = "[26] + [200] - [100]";
    List<string> values = new List<string>();
    
    var items = operation.Split('[');
    
    for (int i = 1; i < items.Length; i++)
    {
        values.Add(items[i].Substring(0, items[i].IndexOf(']')));
    }
    
    foreach (var value in values)
    {
        Console.WriteLine(value);
    }
    
    Console.ReadKey();
