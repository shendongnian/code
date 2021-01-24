    public bool Check(string s)
    {   
	    bool hasOneUpper = s.Count(c => char.IsUpper) == 1;
	    bool hasDigits = s.Any(c => char.IsDigit(c));        
        
        return !string.IsNullOrEmpty(s) && hasOneUpper && hasDigits && s.Length == 8;
    }
