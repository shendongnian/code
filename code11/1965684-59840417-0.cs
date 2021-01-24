    The easy way:
    
    var studentInfo = _context.Student
        .Select(s =>
            new
            {
                Id = s.Id,
                Name = string.IsNullOrEmpty(s.SurName)
                    ? s.FirstName + s.LastName + " - " + s.StudentCode
                    : s.FirstName + " " + s.SurName + " " + s.LastName + " - " + s.StudentCode
            });
    
    ViewBag.Students = new SelectList(studentInfo, "Id", "Name");
