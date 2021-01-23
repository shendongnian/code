	public void DeleteStudentClass(long studentId, long classId)
    {
    	Student student = context.Students.Include(x => x.Classes).Single(x => x.StudentID == studentId);
        using (var context = new DatabaseContext())
        {
            context.Students.Attach(student);
            Class classToDelete = student.Classes.Find(x => x.ClassID == classId);
            if (classToDelete != null)
            {
                student.Classes.Remove(classToDelete);
                context.SaveChanges();
            }
        }
    }
