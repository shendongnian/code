    var schools = dbContext.Schools.Where(school => ...)
        // Keep only the Schools that you actually plan to use:
        .Select(school => new
        {
            // only select the properties that you plan to use
            Id = school.Id,
            Name = school.Name,
            ...
       
            // Only the Students you plan to use:
            Students = school.Students.Where(student => ...)
                .Select(student => new
                {
                    // Again, only the properties you plan to use
                    Id = student.Id,
                    Name = student.Name,
                    // no need for the foreign key: you already know the value
                    // SchoolId = student.SchoolId,
                }),
         });
