    var distinctList = listOfSubjects
                         .GroupBy(s => s.SubjectName)    // group by names
                         .Select(g => g.First());        // take the first group
    
    foreach (var subject in distinctList)
    {
        Console.WriteLine(subject.SubjectName);
    }
