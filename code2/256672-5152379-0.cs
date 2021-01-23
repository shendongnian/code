    var people = new List<Person> { 
        new Person { FirstName = "John", LastName = "Leidegren", Age = 25 },
        new Person { FirstName = "John", LastName = "Doe", Age = 25 },
        new Person { FirstName = "Not john", LastName = "Doe", Age = 26 },
    };
    foreach (var g in (from p in people
                       group p by new { p.Age, p.FirstName }))
    {
        Console.WriteLine("Count: {0}", g.Count());
        foreach (var person in g.OrderBy(x => x.FirstName))
        {
            Console.WriteLine("FirstName: {0}, LastName: {1}, Age: {2}"
                , person.FirstName
                , person.LastName
                , person.Age);
        }
    }
