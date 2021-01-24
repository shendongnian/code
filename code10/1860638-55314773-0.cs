    List<Courses> courses = courseList .GroupBy(
            d => new { d.MajorNameID , d.MajorName },
            d => d.MajorName,
            (key, g) => new courses 
            {
                MajorNameID  = key.MajorNameID,
                MajorName  = key.MajorName,
                CourseNames = g.Distinct().ToList()
            }).ToList();
 
