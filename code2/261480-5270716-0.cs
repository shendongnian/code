    public static void ShowTypes<T>(T item)
    {
        Console.WriteLine("T = " + typeof(T));
        Console.WriteLine("item.GetType() = " + item.GetType());
    }
