    var removedList2 = studentList2
        .Where(s2 => !studentList1
        .Any(s1 => s1.StudentID == s2.StudentID));
    foreach (var student in removedList2)
    {
        Console.WriteLine(student);
    }
    // StudentID=4 StudentName=Ram
    // StudentID=5 StudentName=Ron
