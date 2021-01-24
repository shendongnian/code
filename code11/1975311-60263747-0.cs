    var results = StudentsList
            .Where(x => x.University == "OPQ")
            .GroupBy(x => x.GroupID)
            .Select(g => g.First())
            .ToList();
		
		results.ForEach(x => x.IsQualified = true);
		
		foreach(var item in results)
			Console.WriteLine("Group:" + item.GroupID + " Student:" + item.Student +  " IsQualified:" + item.IsQualified);
