    courses.GroupBy(c => c.CourseID)
        .Select(g => new 
        {
            Id = g.Key, 
            Months = String.Join(", ", g.Select(c => c.Month).ToArray()) 
        });
