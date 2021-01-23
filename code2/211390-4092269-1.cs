    List<Person> persons = new List<Person>( new[]{new Person { Name = "Fredrik Mörk" }});
    Group smallGroup = new Group(persons);
    Console.WriteLine("First iteration");
    foreach (var person in smallGroup.Persons)
    {
        Console.WriteLine(person.Name);
        person.Name += " [altered]";
    }
    Console.WriteLine("Second loop");
    foreach (var person in smallGroup.Persons)
    {
        Console.WriteLine(person.Name); // prints "Fredrik Mörk [altered]"
    }
