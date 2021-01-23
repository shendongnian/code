    List<int> integers = new List<int> { 1, 2, 3 };
    IEnumerable enumerable = integers;
    foreach (string s in enumerable)
    {
        Console.WriteLine(s);
    }
