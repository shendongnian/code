    static void DoStuff(TextWriter output)
    {
        output.WriteLine("doing stuff");
    }
    static void Main()
    {
        DoStuff(Console.Out);
        using( var sw = new StreamWriter("file.txt") )
        {
            DoStuff(sw);
        }
    }
