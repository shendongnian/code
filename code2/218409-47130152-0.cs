	public void InsertStudentClass (long studentId, long classId)
    {
        using (var context = new DatabaseContext())
        {
            Student student = new Student { StudentID = studentId };
            context.Students.Add(student);
            context.Students.Attach(student);
            Class class = new Class { ClassID = classId };
            context.Classes.Add(class);
            context.Classes.Attach(class);
            student.Classes = new List<Class>();
            student.Classes.Add(class);
            context.SaveChanges();
        }
    }
	
