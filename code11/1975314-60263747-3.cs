    var results = StudentsList
            .Where(x => x.University == "OPQ")
            .GroupBy(x => x.GroupID)
            .Select(g => 
					{
						var firstItem = g.First();
						firstItem.IsQualified = true;
						
						return firstItem;
					}).ToList();
`
  [1]: https://dotnetfiddle.net/l3p469
