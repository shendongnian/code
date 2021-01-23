    static void Print(IEnumerable values)
    {
        Console.Write("{ ");
        string.Join(",", values);
        foreach(var value in values) Console.Write(string.Format("{0}, ",value));
        Console.WriteLine("} ");
    }
