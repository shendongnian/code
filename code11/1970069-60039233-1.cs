    static void Main()
    {
        Person person  = new Person();
        Person person2 = new Person();
        Person current = new Person();
        person.Name  = "John";
        person2.Name = "Doe";
        current.Name = "Robert";
        person  = new Person(current); // Using Copy Constructor.
        person2 = current.Copy();      // Using Copy() method.
        current.Change();  // Only changes current, not person or person2.
    }
