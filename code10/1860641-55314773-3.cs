    List<Courses> courses = courseList .GroupBy(
            d => new { d.MajorNameID , d.MajorName },
            d => d.MajorName,
            (key, g) => new Courses 
            {
                MajorNameID  = key.MajorNameID,
                MajorName  = key.MajorName,
                CourseNames = g.Select(x => x.CourseName).Distinct().ToList()
            }).ToList();
