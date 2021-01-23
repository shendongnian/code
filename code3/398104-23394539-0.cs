        var list =
            (IList<Student>) new List<Student>
            {
                new Student {FirstName = "Jane"}, 
                new Student {FirstName = "Bill"},
            };
        var allStudents = list.Union(
            new List<Student> {new Student {FirstName = "Clancey"}})
               .OrderBy(s => s.FirstName).ToList();
        foreach (var s in allStudents)
        {
            Console.WriteLine("FirstName = {0}", s.FirstName);
        }
