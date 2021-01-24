    static void Main()
    {
        var src = new List<int>();
        for (int i = 0; i < 200; i++)
        {
            src.Add(i);
        }
        var linqRetval = src.Select(x => new
        {
            Id = x,
            First = $"Hello{x}",
            Second = $"World{x}"
        }).ToList();
        SomeFunction(linqRetval);
    }
    static void SomeFunction(dynamic input)
    {
        foreach (var item in input)
        {
        }
    }
