    var teacher1 = ...;
    var teacher2 = ...;
    context.Entry(teacher1).State = EntityState.Unchanged;
    context.Entry(teacher2).State = EntityState.Unchanged;
    List<Student> students = new List<Student>()
        {
            new Student(){Name = "Student 1", Teacher = teacher1 },
            new Student(){Name = "Student 2", Teacher = teacher1 },
            new Student(){Name = "Student 3", Teacher = teacher2 },
            new Student(){Name = "Student 4", Teacher = teacher2 },
        };
    context.Students.AddRange(students);
    context.SaveChanges();
