    public static string MatchEval(Match m)
    {
        return m.ToString().ToUpper();
    }
    
    static void Main(string[] args)
    {
        string text = "This is some sample text.";
    
        Console.WriteLine(text);
    
        string result = Regex.Replace(text, @"\w+", new MatchEvaluator(MatchEval));
    
        Console.WriteLine(result);
    }
