		string games = "Name: game1, StatusName Name: game2,".Trim(',');
		List<string> str = games.Split(',').ToList();
		List<string>result = new List<string>();
		
		foreach(string i in str)
			result.Add(i.Split(' ').LastOrDefault());
		
		foreach(string r in result)
			Console.WriteLine(r);
