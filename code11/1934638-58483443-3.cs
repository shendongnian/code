    var studentsWithNewNames = studentList2.Where(s2 =>
        studentList1.Any(s1 =>
            s1.StudentId == s2.StudentId &&
            !s1.StudentName.Equals(s2.StudentName, StringComparison.OrdinalIgnoreCase)));
    foreach (var newNameStudent in studentsWithNewNames)
    {
        // Update student with newNameStudent.StudentId to newNameStudent.StudentName
    }
