    public static bool IsNotEmpty(string value)
    {
        return !IsEmpty(value);
    }
    public static bool IsEmpty(string value)
    {
        return !IsNotEmpty(value);
    }
    public static void Main()
    {
        bool empty = IsEmpty("Hello World");
    }
