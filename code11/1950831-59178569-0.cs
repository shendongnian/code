    public static void Main()
	{
		string rqx = @"([:])\w+";
		string sql = "select * from table where field1 = :param1 and field2 = :param2 And field3 = :param4 ";
		Match[] matches = Regex.Matches(sql, rqx)
                       .Cast<Match>()
                       .ToArray();
		
	    
		foreach(var p in matches)
		{
			Console.WriteLine(p);
		}
	}
