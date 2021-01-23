    delegate int StringIntParse(string value);
    
    	public static int Main(string[] args)
    	{
    		StringIntParse p = int.Parse;
    		Console.WriteLine(p("34"));
    		Console.WriteLine(p.DynamicInvoke(new object[] { "43" }));
    		return 0;
    	}
