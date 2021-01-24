	var sortedStudents = students
		.OrderByDescending(s => s.LastName)
		.ThenBy(s => s.Degree)
		.ThenBy(s => s.Grade)
		.ThenBy(s => s.FirstName);
		
	foreach (var student in sortedStudents)
	{
		Console.WriteLine("{0}", student);
	}
