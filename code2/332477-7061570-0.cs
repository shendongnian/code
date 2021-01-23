    Classroom cr = new Classroom();
    Classroom.StudentRow student = cr.Student.NewStudentRow();
    student.FirstName = "Bob";
    student.LastName = "Villa";
    student.GroupID = 4;
    Console.WriteLine(student.Group.GroupName); // Error
