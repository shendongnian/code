    var stud = studentList.GroupBy(g => g.CourseScore)
    						.Select(i => new
    						{
    							CourseScore = i.Key,
    							StudentNames = String.Join(",", i.Select(s => s.FullName))
    						})
    						.OrderByDescending(o => o.CourseScore).FirstOrDefault();
    
    Console.WriteLine(stud.StudentNames);
