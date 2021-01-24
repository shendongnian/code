    var distinctSubjectNames = listOfSubjects
        .Select(s => s.SubjectName)
        .Distinct();
    foreach (string subjectName in distinctSubjectNames) {
            Console.WriteLine(subjectName);
    }
    
