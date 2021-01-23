        var list =
            (IList<Student>) new [] 
            {
                new Student {FirstName = "Jane"}, 
                new Student {FirstName = "Bill"},
            };
        var allStudents = list.Union(
            new [] {new Student {FirstName = "Clancey"}})
               .OrderBy(s => s.FirstName).ToList();
        allStudents[0].FirstName = "Billy";
        foreach (var s in allStudents)
        {
            Console.WriteLine("FirstName = {0}", s.FirstName);
        }
