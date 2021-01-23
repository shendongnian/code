    static void Dump(this IEnumerable<string> ss)
    {
        foreach(var s in ss)
        {
            Console.WriteLine(s);
        }
    }
