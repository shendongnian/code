		var result = list.GroupBy(p => 
					{
						var indexOf = p.PagePath.IndexOf('/');
						return indexOf > 0 ? p.PagePath.Substring(0, indexOf) : p.PagePath;
					});
		foreach(var item in result)
		{
			Console.WriteLine("Group: " + item.Key);
			foreach(var item2 in item.ToList())
			{
				Console.WriteLine(item2.Id + "|" + item2.PagePath + "|" + item2.Date);
			}
		}
