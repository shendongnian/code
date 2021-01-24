    var results = StudentsList.GroupBy(x => x.GroupID)
			               .Where(g => !g.Any(p => p.Student == "Adam") && g.Any(x => x.University == "OPQ"))
						   .Select(g => 
									{
										var firstItem = g.First(x => x.University == "OPQ");
										firstItem.IsQualified = true;
										return firstItem;
									}).ToList();
