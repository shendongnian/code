	var jsonStudents = new List<object>();
	foreach (var student in students)
	{
		var tempStudent = new
		{
			student.Id,         //anonymous properties automatically pick up the name of the property you pass them, this will be called Id
			FullName = student.FirstName + " " + student.LastName, //if you want to name a property yourself use this notation
			Projects = new List<object>()
		};
		foreach (var project in student.Projects)
		{
			var tempProject = new {
				project.Id,
				project.Name,
				Tasks = new List<object>()
			};
			foreach (var task in project.Tasks)
			{
				tempProject.Tasks.Add(new {
					task.Id,
					task.Name
				});
			}
			tempStudent.Projects.Add(tempProject);
		}
		jsonStudents.Add(tempStudent);
	}
	var serializer = new JavaScriptSerializer();
	var jsonString = serializer.Serialize(jsonStudents);
