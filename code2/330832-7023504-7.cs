    public Person(string name = "John")
    {
        this.name = name;
        this.NameChanged += builtin_NameChanged;
    }
    private static void builtin_NameChanged(object sender, EventArgs e)
    {
        Person person = (Person)sender; // cast back to a Person so we can see what's changed
        Console.WriteLine("The name changed!");
        Console.WriteLine("It is now: " + person.Name); // let's print the name
    }
