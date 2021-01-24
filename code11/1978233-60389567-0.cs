		var result = list.GroupBy(p => 
								  {
									  var indexOf = p.PagePath.IndexOf('/');
									  var length = indexOf  > 0 ?  indexOf : p.PagePath.Length;
									  return p.PagePath.Substring(0, length);
								  });
		foreach(var item in result)
		{
			Console.WriteLine("Group: " + item.Key);
			foreach(var item2 in item.ToList())
			{
				Console.WriteLine(item2.Id + "|" + item2.PagePath + "|" + item2.Date);
			}
		}
