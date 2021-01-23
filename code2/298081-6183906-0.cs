    List<Person> list = new List<Person>
    {
        new person{ID=1,Name="jhon",salaty=2500},
        new person{ID=2,Name="Sena",salaty=1500},
        new person{ID=3,Name="Max",salaty=5500}.
        new person{ID=4,Name="Gen",salaty=3500}
    };
    // The "Where" LINQ operator filters a sequence
    var highEarners = list.Where(p => p.salaty > 3000);
    foreach (var person in highEarners)
    {
        Console.WriteLine(person.Name);
    }
