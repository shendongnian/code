     public Student GetSingleStudent(int id)
            {
    
                var student = _context.Students
                    .Include(e=>e.Education)
                    .FirstOrDefault(s => s.Id == id);
                return student;
            }
