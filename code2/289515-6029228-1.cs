    var jsonStudents = new List<object>();
	foreach (var student in students)
	{
		jsonStudents.Add(new
		{
			student.Id,         //anonymous properties automatically pick up the name of the property you pass them, this will be called Id
			FullName = student.FirstName + " " + student.LastName, //if you want to name a property yourself use this notation
			Projects = student.Projects.Select(p => new //this will be an enumerable of nested anonymous objects, we're partially selecting project properties
			{
				p.Id,
				p.Name,
				Tasks = p.Tasks.Select(t => new //nesting another level
				{
					t.Id,
					t.Name
				})
			})
		});
	}
	var serializer = new JavaScriptSerializer();
	var jsonString = serializer.Serialize(jsonStudents);
