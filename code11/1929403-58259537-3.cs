    public bool Check(string s)
    {   
	    bool hasOneUpper = s.Count(char.IsUpper) == 1;
	    bool hasOneDigit = s.Count(char.IsDigit) == 1;        
        
        return hasOneUpper && hasOneDigit && s.Length == 8;
    }
