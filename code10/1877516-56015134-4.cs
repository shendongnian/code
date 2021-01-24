    var ids = new HashSet<int>(studentList1.Select(s1 => s1.StudentID));
    var removedList2 = studentList2.Where(s2 => !ids.Contains(s2.StudentID));
    foreach (var student in removedList2)
    {
        Console.WriteLine(student);
    }
    // StudentID=4 StudentName=Ram
    // StudentID=5 StudentName=Ron
