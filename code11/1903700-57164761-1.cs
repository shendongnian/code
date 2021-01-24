    Person p = new Person { FirstName = "John", LastName = "Miller" };
    object o = new Person { FirstName = "Tina", LastName = "Smith" };
    Console.WriteLine(p.FirstName + " " + p.LastName); // OK
    Console.WriteLine(o.FirstName + " " + o.LastName); // DOES NOT WORK
    // but
    if (o is Person p2) {
        Console.WriteLine(p2.FirstName + " " + p2.LastName); // OK
    }
    // or
    Console.WriteLine(((Person)o).FirstName + " " + ((Person)o).LastName); // OK
