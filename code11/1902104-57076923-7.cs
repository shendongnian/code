    if (student.ImageUrl != null)
    {              
     _context.Student.Add(existingStudent);
     _context.Entry(existingStudent).State EntityState.Modified;
     //_context.Student.Update(existingStudent); //You can also use this. Comment out the upper two lines
     _context.SaveChanges();
    }
    else
    {
        // updating student.
        _context.Student.Attach(existingStudent);
        _context.Entry(existingStudent).State = EntityState.Modified; 
        _context.Entry(existingStudent).Property(x => x.ImageUrl).IsModified=false; 
        _context.SaveChanges();
    }
