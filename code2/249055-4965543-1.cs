    static void Main()
    {
        List<Person> person = new List<Person>
        {
            new Person { Name = "Maria Anders", Age = 21 },
            new Person { Name = "Ana Trujillo", Age = 55 },
            new Person { Name = "Thomas Hardy", Age = 40 },
            new Person { Name = "Laurence Lebihan", Age = 18 },
            new Person { Name = "Victoria Ashworth", Age = 16 },
            new Person { Name = "Ann Devon", Age = 12 }
        };
    
        person.ForEach(x => Dump(x));
    
    }
    
    static void Dump(Person p)
    {
        Console.WriteLine("{0} {1}", p.Name, p.Age);
    }
    
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
