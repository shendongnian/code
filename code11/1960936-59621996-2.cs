        var groupedEnrollment = enrollments.GroupBy(p => p.StudentId)
											.Select(g => new 
											{
												StudentId = g.Key,
												Courses = g.Select(p => p.CourseId).ToArray() 
											});
		var result = groupedEnrollment.Where(g => 
											 g.Courses.Length == courses.Length && 
											 g.Courses.Intersect(courses).Count() == courses.Length);
