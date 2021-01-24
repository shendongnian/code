    var Result = dbContext.Schools
        .Where(school => ...)
        .Select(school => new
        {
            Id = school.Id,
            ...
            Students = school.Students
                .Where(student => ...)
                .Select(student => new
                {
                     Id = student.Id,
                     ...
                })
                .ToList(),
        });
