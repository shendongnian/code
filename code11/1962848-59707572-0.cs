    var top3 = list.GroupBy(x => x)
                   .OrderByDescending(x => x.Count())
                   .Take(3)
                   .Select(x => x.Key);
		
	Console.WriteLine(string.Join(" ", top3)); // output 5 3 4
