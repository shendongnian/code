    class Program
    {
    	static void Main(string[] args)
    	{
    		Console.WriteLine(Normalize("SMITH 9-2 #3-10H13"));
    		Console.WriteLine(Normalize("RODGER 3-1 #5-11H17"));
    		Console.ReadLine();
    	}
    
    	static string Normalize(string input)
    	{
    		const string pattern = @"([a-zA-Z]+)\s+(\d{1,2})-(\d{1,2})\s+(#\d-\d{2}[A-Z]\d{2})";
    		var regex = new Regex(pattern);
    		var match = regex.Match(input);
    		return match.Groups[1].Value + " " +
    			match.Groups[2].Value.PadLeft(2, '0') + "-" +
    			match.Groups[3].Value.PadLeft(2, '0') + " " +
    			match.Groups[4].Value;
    	}
    }
