    private static void assign(ref int i)
    {
        i = 42;
    }
    public static void Main()
    {
        Wrap<int> element = 7;
        var vars = new Wrap<int>[] {1, 2, element, 3, 4};
        Console.WriteLine(vars[2]);
        assign(ref vars[2].Value);
        Console.WriteLine(element);
        Console.ReadKey();
    }
