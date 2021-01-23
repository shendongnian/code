    class Person
    {
        int Id{ get; set; }
        string Name { get; set; }
    }
    ...
    var people = new List<Person>()
    {
        new Person{ Id = 1, Name = "Steve" },
        new Person{ Id = 2, Name = "Bill" },
        new Person{ Id = 3, Name = "John" },
        new Person{ Id = 4, Name = "Larry" }
    }
    SelectList List = new MultiSelectList(people, "Id", "Name", new[]{ 2, 3 });
