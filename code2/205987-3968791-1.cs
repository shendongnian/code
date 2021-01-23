    public static string EntityNumbersToEntityValues(string s)
    		{
    			Match match = Regex.Match(s, @"&#(\d+);", RegexOptions.IgnoreCase);
    			while(match.Success)
    			{
    				string v = match.Groups[1].Value;
    				string c = char.ConvertFromUtf32(int.Parse(v));
    				s = Regex.Replace(s, string.Format("&#{0};", v), c);
    				match = match.NextMatch();
    			}			
    			return s;
    		}
