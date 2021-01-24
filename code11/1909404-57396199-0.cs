    People.GroupBy(c => new
            {
                c.Name,
                c.Age
            })
           .Select(g => new Person() 
                      { Name = g.Key.Name, 
                        Age = g.Key.Age,
                        Interests = g.SelectMany(r => r. Interests).ToList()})
