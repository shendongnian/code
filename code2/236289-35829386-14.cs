    Person person = new Person { Name = "John" };
    WriteName(person);
    public static void WriteName(NotNull<Person> person)
    {
        Console.WriteLine(person.Value.Name);
    }
