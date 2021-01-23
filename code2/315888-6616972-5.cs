    static void Print<T>(IEnumerable<T> values)
    {
        Console.Write("{ ");
        Console.Write(string.Join(",", values));
        Console.WriteLine(" }");
    }
