    private static Regex tagParsing = new Regex(
    	@"{([\w]+)(?:\(""([^""]+)""\)|\(([^\)]+)\))*\.([\w]+)\(""([^""]+)""\)}", 
    	RegexOptions.Compiled);
    
    public static void TestMethod()
    {
    	Match m = tagParsing.Match(@"myfile {System.Date(""DD_MM_YY HH:NN"")}.txt");
    }
