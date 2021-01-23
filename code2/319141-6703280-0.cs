    enum E
    {
        A = 2,
        B = 3
    }
    public static string GetLiteral<T>(object value)
    {
        return Enum.GetName(typeof(T), value);
    }
    static void Main(string[] args)
    {
        Console.WriteLine(GetLiteral<E>(2));
        Console.WriteLine(GetLiteral<E>(3));
    }
