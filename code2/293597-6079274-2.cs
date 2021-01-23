    List<Person> list = new List<Person>
    {
        new Person { Name = "John", Age = 24 }, 
        new Person { Name = "Tom", Age = 35 },
        new Person { Name = "Mike", Age = 42 },
        new Person { Name = "Steve", Age = 51 }
    };
    var phil = new Person { Name = "Phil", Age = 45 };
    var twoNearest = from p2 in
                    (from p1 in list
                    where p1.Age > phil.Age || p1.Age < phil.Age
                    select new {
                        Name = p1.Name,
                        Age = p1.Age,
                        Younger = p1.Age < phil.Age
                    })
                group p2 by p2.Younger into split
                from p in split
                where (p.Age == split.Max(a => a.Age) && p.Younger) || (p.Age == split.Min(a => a.Age) && !p.Younger)
                select new Person {
                    Name = p.Name,
                    Age = p.Age,
                };
