    if (student.ImageUrl != null)
    {              
     _context.Entry(existingStudent).CurrentValues.SetValues(student);
     _context.Entry(existingStudent).State EntityState.Modified;
     _context.Entry(existingStudent).Update(setting);
     _context.SaveChanges();
    }
    else
    {
        // updating student.
        _context.Entry.Attach(existingStudent);
        _context.Entry(existingStudent).State = EntityState.Modified; 
        _context.Entry(existingStudent).Property(x => x.ImageUrl).IsModified=false; 
        _context.SaveChanges();
    }
