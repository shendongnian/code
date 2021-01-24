    // add more students if needed.
	var students = new Student[] {  new Student
										{
											name = "Alex",
											score = 190
										},
										new Student
										{
											name = "Misha",
											score = 177
										}};
	foreach (var s in students)
	{
		Console.Write($"Student name is {s.name}");
	}
									
