    public static void DoStuff<T>(ICollection<T> source)
        where T : new()
    {
        T c = new T();
        source.Add(c);
    }
