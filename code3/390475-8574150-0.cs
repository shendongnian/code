        static void Main(string[] args)
        {
            var m = new Person { Id = 1, Name = "Mr Manager"};
            var r1 = new Person { Id = 2, Name = "Mr ReportsToManager"};
            var r2 = new Person { Id = 3, Name = "Mrs ReportsToManager"};
            var resp = new Responsibility
            {
                Id = 1,
                ResponsibilityType = "Manages",
            };
            resp.People.Add(r1);
            resp.People.Add(r2);
            m.Responsibilities.Add(resp);
            m.Responsibilities.First().People.ToList().ForEach(r => Console.WriteLine(r.Name));
        }
    Mr ReportsToManager
    Mrs ReportsToManager
