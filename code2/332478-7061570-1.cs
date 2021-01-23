    Classroom cr = new Classroom();
    Classroom.GroupRow group4 = cr.Group.NewGroupRow();
    group4.GroupName = "Group 4";
    cr.Group.AddGroupRow(group4);
    Classroom.StudentRow student = cr.Student.NewStudentRow();
    student.FirstName = "Bob";
    student.LastName = "Villa";
    student.GroupRow = group4;
    Console.WriteLine(student.GroupRow.GroupName); // Works
