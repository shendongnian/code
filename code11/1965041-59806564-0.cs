    var gen = new Dictionary<int, int>();
    if (quantity > (max - min))
        throw new ArgumentOutOfRangeException("Quantiy must be smaller than range");
    while (gen.Count < quantity)
    {
        temp = rnd.Next(min, max);
        if(!gen.ContainsKey(temp))
            gen.Add(temp, temp);
    }
    foreach (int num in gen.Values)
    {
        Console.WriteLine(num);
    }
