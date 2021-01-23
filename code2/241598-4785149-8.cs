    var people = new Person[]
                        {
                            new Person() {Name = "John", Age = 40},
                            new Person() {Name = "John", Age = 20},
                            new Person() {Name = "Agnes", Age = 11}
                        };
    
    foreach(var per in  people.OrderByMany(x => x.Name, x => x.Age))
    {
        Console.WriteLine("{0} Age={1}",per.Name,per.Age);
    }
    
