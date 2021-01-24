    studentList2.Where(s2 => studentList1.Any(s1 =>
        s1.StudentId == s2.StudentId &&
        !s1.StudentName.Equals(s2.StudentName, StringComparison.OrdinalIgnoreCase)))
        .ToList()
        .ForEach(student =>
        {
            // update student.StudentId with student.StudentName
        });
