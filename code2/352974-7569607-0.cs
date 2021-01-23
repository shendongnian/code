    public MapReader(string fName)
    {
        FileName = fName;
    }
    public static MapReader FromConsole()
    {
        Console.WriteLine("Input valid file name:");
        string name = Console.ReadLine();
        return new MapReader(name);
    }
