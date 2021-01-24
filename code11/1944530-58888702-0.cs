    interface IPerson
    {
        String Name    { get; }
        String SurName { get; }
    }
    class Director : IPerson { ... }
    class Actor    : IPerson { ... }
