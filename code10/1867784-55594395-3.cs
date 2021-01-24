    static void Main(string[] args)
    {
        Console.WriteLine("Hello World!");
        List<ClassA> listAs = new List<ClassA>()
        {
            CreateAvailablePerson("PersonA"),
            CreateAvailablePerson("PersonB"),
            CreateAvailablePerson("PersonC"),
        };
    }
    
    private static ClassA CreateAvailablePerson(string name)
    {
        return new ClassA() { GroupNumber = 1, Name = name, IsAvailable = true };
    }
