    private static Regex regex = new Regex(@"^(\s)*(\d ){6}\d(\s)*$"); 
    
    private static bool IsValid(string s)
    {
    	return regex.IsMatch(s);
    }
