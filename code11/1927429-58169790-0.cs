    List<Student> students = new List<Student>();
    students.Add(new Student { Id = 1, Name = "Ramesh", Rank = 3 });
    students.Add(new Student { Id = 2, Name = "Kapil", Rank = 1 });
    students.Add(new Student { Id = 3, Name = "Suresh", Rank = 2 });
     
    var studentsOrderByRank = from student in students
                                orderby student.Rank
                                select student;
     
    Console.WriteLine("Sorted Students:");
    foreach(var student in studentsOrderByRank)
    {
        Console.WriteLine(student.Name);
    }
