    var result = dbContext.Schools
        .Where(school => school.Id == 10)
        .Select(school => new
        {
            // Select only the School properties you plan to use
            Id = school.Id,
            Name = school.Name,
            Address = school.Address,
            Students = school.Students
                .Where(student => ...) // only if you don't want all Students
                .Select(student => new
                {
                     // again: select only the properties you plan to use
                     Id = student.Id,
                     Name = student.Name,
                     ...
                     // not needed, you already know the value!
                     // SchoolId = student.SchoolId,
                })
                .ToList(),                     
        })
        .FirstOrDefault();
