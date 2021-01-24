    var teacher1 = new Teacher(){ Name = "Teacher 1" };
    var teacher2 = new Teacher(){ Name = "Teacher 2" };
    
    context.Teachers.AddRange(teacher1, teacher2);
    
    List<Student> students = new List<Student>()
        {
            new Student(){Name = "Student 1", TeacherID = teacher1.ID },
            new Student(){Name = "Student 2", TeacherID = teacher1.ID },
            new Student(){Name = "Student 3", TeacherID = teacher2.ID },
            new Student(){Name = "Student 4", TeacherID = teacher2.ID }
        };
    
    context.Students.AddRange(students);
    context.SaveChanges();
