    var teacher1 = new Teacher(){Name = "Teacher 1"};
    var teacher2 = new Teacher(){Name = "Teacher 2"};
    List<Student> students = new List<Student>()
        {
            new Student(){Name = "Student 1", Teacher = teacher1 },
            new Student(){Name = "Student 2", Teacher = teacher1 },
            new Student(){Name = "Student 3", Teacher = teacher2 },
            new Student(){Name = "Student 4", Teacher = teacher2 },
        };
    context.Teachers.AddRange(teacher1, teacher2);
    context.Students.AddRange(students);
    context.SaveChanges();
