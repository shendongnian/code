    static void Main(string[] args)
    {
        Console.WriteLine("Hello World!");
        List<ClassA> listAs = new List<ClassA>()
        {
            Create("PersonA"),
            Create("PersonB"),
            Create("PersonC"),
        };
        Person Create(string name) => new ClassA() { GroupNumber = 1, Name = name, IsAvailable = true };
    }
