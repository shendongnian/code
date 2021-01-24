    using (TestDbContext ctx = new TestDbContext())
    {
        var tmp = ctx.AssignmentStudents
            .Include(s => s.Assignment) // Include all Childs..
            .ThenInclude(a => a.Lesson)
            .ThenInclude(l => l.Unit)
            .ThenInclude(u => u.Course)
            .ThenInclude(c => c.GradeLevel)
            .Where(a => a.LessonId == 123)
            .GroupBy(g => // Group by your Key-Values Grade and Course (You could take names instead of ids. Just for simplification)
            new
            {
                GradeLevel = g.Assignment.Lesson.Unit.Course.GradeLevel.Id,
                Course = g.Assignment.Lesson.Unit.Course.Id
            })
            .Select(s => // Select the result into an anonymous type
            new
            {
                GradeLevels = s.Key.GradeLevel, // with same keys like grouping
                Course = s.Key.Course,
                AverageObtainedMarks = s.Average(a => a.ObtainedMarks) // and an average ObtainedMarks from objects matching the key
            })
            .Where(s => s.GradeLevel == 1);
        foreach (var t in tmp)
        {
            Console.WriteLine(t.GradeLevels + " " + t.Course + ": " + t.AverageObtainedMarks);
        }
    }
