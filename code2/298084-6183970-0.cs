    var persons = new List<Person>
        {
            new Person {ID = 1, Name = "jhon", Salary = 2500},
            new Person {ID = 2, Name = "Sena", Salary = 1500},
            new Person {ID = 3, Name = "Max", Salary = 5500},
            new Person {ID = 4, Name = "Gen", Salary = 3500}
        };
    var acertainperson = persons.Where(p => p.Name == "jhon").First();
    Console.WriteLine("{0}: {1} points",
        acertainperson.Name, acertainperson.Salary);
    jhon: 2500 points
    
    var doingprettywell = persons.Where(p => p.Salary > 2000);
                foreach (var person in doingprettywell)
                {
                    Console.WriteLine("{0}: {1} points",
                        person.Name, person.Salary);
                }
    jhon: 2500 points
    Max: 5500 points
    Gen: 3500 points
    
            var astupidcalc = from p in persons
                              where p.ID > 2
                              select new
                                         {
                                             Name = p.Name,
                                             Bobos = p.Salary*p.ID,
                                             Bobotype = "bobos"
                                         };
            foreach (var person in astupidcalc)
            {
                Console.WriteLine("{0}: {1} {2}",
                    person.Name, person.Bobos, person.Bobotype);
            }
    Max: 16500 bobos
    Gen: 14000 bobos
