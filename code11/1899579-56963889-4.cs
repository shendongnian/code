    var result = new List<List<string>>();
    var projects = new List<Project>
    {
        new Project{ Name = "prj A",
            startdate = new DateTime(2019, 1, 1), enddate = new DateTime(2019, 2, 10) },
        new Project{ Name = "prj B",
            startdate = new DateTime(2019, 1, 29), enddate = new DateTime(2019, 3, 15) },
        new Project{ Name = "prj C",
            startdate = new DateTime(2019, 3, 21), enddate = new DateTime(2019, 5, 2) },
        new Project{ Name = "prj D",
            startdate = new DateTime(2019, 5, 7), enddate = new DateTime(2019, 6, 10) },
        new Project{ Name = "prj E",
            startdate = new DateTime(2019, 6, 11), enddate = new DateTime(2019, 7, 30) }
    };
    projects = projects.OrderBy(x => x.startdate).ToList();
    
    for (var i = 0; i < projects.Count; i++)
    {
        var project = projects[i];
        if (projects[0] != project 
            && 
            (project.startdate - projects[i - 1].enddate).TotalDays < 2)
            result.Last().Add(project.Name);
        else
            result.Add(new List<string> { project.Name });                                    
    }
	foreach(var gr in result)
		Console.WriteLine(String.Join(", ", gr));
    //prj A, prj B
    //prj C
    //prj D, prj E
