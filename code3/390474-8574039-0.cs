    public class Person
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
        public virtual List<Responsibility> Responsibilities { get; set; }
    }
    
    public class Responsibility
    {
        public int ResponsibilityId { get; set; }
        public string ResponsibilityType { get; set; }
        public virtual List<Person> People { get; set; }
    }
    static void Main(string[] args)
    {
        var m = new Person { PersonId = 1, Name = "Mr Manager"};
        var r1 = new Person { PersonId = 2, Name = "Mr ReportsToManager"};
        var r2 = new Person { PersonId = 3, Name = "Mrs ReportsToManager"};
        var resp = new Responsibility
        {
            ResponsibilityId = 1,
            ResponsibilityType = "Manages",
            People = new List<Person>() { r1, r2 }
        };
        m.Responsibilities = new List<Responsibility>() { resp };
        m.Responsibilities.First().People.ForEach(r => Console.WriteLine(r.Name));
    }
    Mr ReportsToManager
    Mrs ReportsToManager
