    public static void Main(string[] args)
    {
    	var a = new Regex("(?<PageNumber>.{2})(?<ListType>.{2})", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Multiline);
    	var match = a.Match("02KLThisIsATest");
    	
    	foreach (dynamic gr in match.Groups)
    	{
    		//Your code goes here
    		Console.WriteLine(gr.Name + " | " + gr.Value);
    	}
    }
