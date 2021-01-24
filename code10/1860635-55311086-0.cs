    List<Courses> courses = courseList.GroupBy(
        d => new { d.MajorNameID, d.MajorName }
        ).Select(g => new Courses
        {
            MajorNameID = g.Key.MajorNameID,
            MajorName = g.Key.MajorName,
            CourseNames = g.Distinct().Select(c => 
                new CourceNames { CourseID = c.CourseID, CourseName = c.CourseName }).ToList()
        }
    ).ToList();
