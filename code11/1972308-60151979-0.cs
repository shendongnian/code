                      db.Students
                      .Include(b => b.Course)
                      .Select(b => new Student()
                      {
                          Id = b.Id,
                          FirstName = b.FirstName,
                          ...
                          Course = db.Courses
                                   .Where(c => c.Id == b.Course.Id)
                                   .Select(c => new Course()
                                   {
                                       Id = c.Id,
                                       Title = c.Title,
                                       ...
                                       NumberOfStudents = c.Student.Count()
                                   })
                                   .FirstOrDefault()
                      }).ToList();
