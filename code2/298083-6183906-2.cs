    List<Person> list = new List<Person>
    {
        new person{ID=1,Name="jhon",salary=2500},
        new person{ID=2,Name="Sena",salary=1500},
        new person{ID=3,Name="Max",salary=5500}.
        new person{ID=4,Name="Gen",salary=3500}
    };
    // The "Where" LINQ operator filters a sequence
    var highEarners = list.Where(p => p.salary > 3000);
    foreach (var person in highEarners)
    {
        Console.WriteLine(person.Name);
    }
