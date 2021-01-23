    var dict = new Dictionary<int, int>();
    foreach (int n in numbers)
    {
        int count;
        dict.TryGetValue(n, out count);
        if (count == 1)
        {
            Console.WriteLine(n);
        }
        dict[n] = count + 1;
    }
