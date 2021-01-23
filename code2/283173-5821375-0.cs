    static void Main(string[] args)
    {
        WriteMulti("A", "B", "C", "D", "E", "F", "G");
        Console.ReadLine();
    }
    static void WriteMulti(params string[] args)
    {
        foreach (string arg in args)
            Console.WriteLine(arg);
    }
