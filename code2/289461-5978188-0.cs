       List<Person> list = new List<Person>()
        {
            new Person { Name="test", Age=1},
            new Person { Name="tester", Age=2}
        };
       var items = list.Select(x =>
            {
                return new
                {
                    Name = x.Name
                };
            }).ToList();
       items.ForEach(o => Console.WriteLine(o.Name));
