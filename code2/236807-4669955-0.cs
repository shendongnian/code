    public static class StringExtenstionMethods
	{
		public static bool DoesNotStartWith(this string source,string target)
		{
			return !source.StartsWith(target);
		}
	}
    var idList = (from s      
	in db.TABLE      
	where s.ID.DoesNotStartWith("0000")      
	select s.ID);
