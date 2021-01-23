    public static void ChangeName(Person p, String name)
    {
        p.Name = name;
    }
    public static Person WithName(Person p, String name)
    {
        return new Person(p) { Name = name };    
    }
