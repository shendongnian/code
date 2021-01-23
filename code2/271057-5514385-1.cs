    using (var context = new MyContext())
    {
        Person person = new Person() { Name = "Spock", Friends = new List<Person>()};
        Person parent = new Person() { Name = "Sarek" };
        Person friend1 = new Person() { Name = "Kirk" };
        Person friend2 = new Person() { Name = "McCoy" };
        person.Parent = parent;
        person.Friends.Add(friend1);
        person.Friends.Add(friend2);
        context.People.Add(person);
        context.SaveChanges();
        // Load with eager loading in this example
        var personReloaded = context.People
            .Where(p => p.Name == "Spock")
            .Include(p => p.Parent)
            .Include(p => p.Friends)
            .First();
    }
