    var groupedPersons = personList.GroupBy(x => x.City);
    foreach (var g in groupedPersons)
    {
        string city = g.Key;
        Console.WriteLine(city);
        foreach (var person in g)
        {
            Console.WriteLine("{0} {1}", person.Name, person.LastName);
        }
    }
