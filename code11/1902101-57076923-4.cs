    public void Edit(Student student)
    {
      var existingStudent = _context.Students.FirstOrDefault(s => s.Id == student.Id);
    
      if (existingStudent != null)
      {
        // updating student.
        _context.Entry.Attach(existingStudent);
        _context.Entry(existingStudent).State = EntityState.Modified; 
        _context.Entry(existingStudent).Property(x => x.ImageUrl).IsModified=false; 
        _context.SaveChanges();
      }
    }
