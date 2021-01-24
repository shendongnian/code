    static void Main(string[] args)
    {
        Console.WriteLine(FindType(FS.Properties.Resources.types, "Name1")); //prints "Type1
        Console.WriteLine(FindType(FS.Properties.Resources.types, "name1")); //prints "No type found
        Console.ReadKey();
    }
