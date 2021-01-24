    public void Edit(Student student)
    {
        var existingStudent = _context.Students.FirstOrDefault(s => s.Id == student.Id);
        if (existingStudent != null)
        {
            //do the update to the database             
            _context.Entry(existingStudent).CurrentValues.SetValues(student);
            _context.Entry(existingStudent).State = System.Data.Entity.EntityState.Modified;
            
            //then update the parent this way
            //first get the particular parent for this student
            var parent = _context.Parents.FirstOrDefault(m => m.StudentId == existingStudent.Id);
            _context.Entry(parent).CurrentValues.SetValues(student.Parents);
            _context.Entry(parent).State = System.Data.Entity.EntityState.Modified;
            
            //do the same for Educations
        }
        _context.SaveChanges();
    } 
