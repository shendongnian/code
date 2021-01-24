    var result = dbContext.Students
        .Where(student => !langIds.Except(student.Languages).Any()
        .Select(student => new
        {
            // Select only the Student properties that you plan to use
            Id = student.Id,
            Name = student.Name,
            ...
            // Only if you plan to use all languages that the Student speaks:
            Languages = student.Languages.Select(language => new
            {
                // again: only the language properties that you plan to use:
                Id = language.Id,
                Code = language.Code,
                Abbreviation = language.Abbreviation,
                ...
                // no need to fill language.Students
            })
            .ToList(),
        });
