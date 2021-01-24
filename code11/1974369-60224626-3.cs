    var result = dbContext.Students
        .Where(student => student.City == "New York)
        .Select(student => new
        {
            // Select only the Student properties that you plan to use:
            Id = student.Id,
            Name = student.Name,
            ...
            Universities = student.UniversityStudentAssociations
                .Select(association => new
            {
                // I only want the university properties
                // again: only the properties that you plan to use:
                UniversityId = association.University.Id,
                UniversityName = association.University.Name,
        }
