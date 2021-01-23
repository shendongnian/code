    static void Print<T>(IEnumerable<T> items)
    {
        var props = typeof(T).GetProperties();
        foreach (var prop in props)
        {
            Console.Write("{0}\t", prop.Name);
        }
        Console.WriteLine();
        foreach (var item in items)
        { 
            foreach (var prop in props)
            {
                Console.Write("{0}\t", prop.GetValue(item, null));
            }
            Console.WriteLine();
        }
    }
