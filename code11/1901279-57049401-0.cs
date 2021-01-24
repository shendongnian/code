        var existingStudent = _context.Student
            .Include(s => s.Siblings)
            .AsNoTracking()
            .Single(s => s.Id == 4);
        if (existingStudent != null)
        {
            existingStudent = student;
            _context.Update(existingStudent);
            _context.SaveChanges();
        }
