    public IActionResult Get(int id)
    {
       var student = dataContext.Students
          .Include(s => s.StudentPublished)
          .Where(s => s.ReferenceNumber == id)
          .FirstOrDefault();
       return Ok(student);
    }
