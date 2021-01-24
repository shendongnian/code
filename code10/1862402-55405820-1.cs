    List<person> persons = new List<person>()
                {
                    new person{ ID = 1,Name="Ali"}
                    ,new person{ ID = 2,Name="Gorge"}
                    ,new person{ ID = 3,Name="Alex"}
                    ,new person{ ID = 4,Name="Liz"}
                    ,new person{ ID = 5,Name="Scott"}
                    ,new person{ ID = 6,Name="Abby"}
                    ,new person{ ID = 7,Name="Sarah"}
                };
    
                Parallel.ForEach(persons, (p) =>
                {
                    Console.WriteLine($"Id : {p.ID} ,Name : {p.Name}");
                });
