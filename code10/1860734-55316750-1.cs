    List<Subject> listOfSubjects = new List<Subject>() 
                 { 
                     new Subject("Alice"),
                     new Subject("Bob"),
                     new Subject("Alice")
                 };
    var distinctList = listOfSubjects.GroupBy(s => s.SubjectName).Select(g => g.First());
    
    foreach (var subject in distinctList)
    {
        Console.WriteLine(subject.SubjectName);
    }
