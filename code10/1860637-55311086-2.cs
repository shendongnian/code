    List<Courses> courses2 = courseList.GroupBy(
        d => new { d.MajorNameID, d.MajorName }, // key selector
        c => new CourceNames { CourseID = c.CourseID, CourseName = c.CourseName }, // element selector
        (key, g) => new Courses
        {
            MajorNameID = key.MajorNameID,
            MajorName = key.MajorName,
            CourseNames = g.Distinct().ToList()
        }
    ).ToList();
