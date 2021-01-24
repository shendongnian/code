    var results = dbContext.Schools
        .Select(school => new
        {
            Id = school.Id,
            Name = school.Name,        // only if you want other School properties
            ...
            // All Students that attend this School
            // == that have a foreign key equal to School.Id
            Students = dbContext.Students.Select(student => new
            {
                // Select only the properties that you plan to use
                Id = student.Id,
                Name = student.Name,
                ...
                // not needed: you know the value:
                // SchoolId = student.SchoolId,
            })
            .ToList(),
            // all Teachers that teach on this School
            // == that have a foreign key equal to School.Id
            // == that have a foreign key equal to the foreign key of all Students on this School
            Teachers = dbContext.Teachers.Select(teacher => new
            {
                // again: select only properties that you plan to use
                Id = teacher.Id,
                Name = teacher.Name,
                ...
                // not needed: you know the value:
                // SchoolId = teacher.SchoolId,
            })
            .ToList(),
        });
