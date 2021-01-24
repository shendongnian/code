    public IActionResult Get(int id)
    {
       var student = dataContext.Students
          .Where(s => s.ReferenceNumber == id)
          .Include(s => s.StudentPublished)
          .FirstOrDefault();
       return Ok(student);
    }
