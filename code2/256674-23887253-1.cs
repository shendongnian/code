    List<Person> persons = new List<Person>
    {
       new Person{Name = "A", SSN="1", Age = 23},
       new Person{Name = "A", SSN="2", Age = 23},
       new Person{Name = "B", SSN="3", Age = 24},
       new Person{Name = "C", SSN="4", Age = 24},
       new Person{Name = "D", SSN="5", Age = 23}
    };
    var out1 = persons.GroupBy(p => new { p.Age, p.Name }).Select(s => new { Name = s.Key.Name,age = s.Key.Age, cnt = s.Count() }); ;
    System.Threading.Tasks.Parallel.ForEach(out1, item => Console.WriteLine(item.Name + " " + item.age + " " + item.cnt));  
