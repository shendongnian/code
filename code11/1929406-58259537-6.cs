    public bool Check(string s)
    {   
	    bool hasOneUpper = s.Count(c => char.IsUpper(c)) == 1;
	    bool hasDigits = s.Any(c => char.IsDigit(c));        
        
        return !string.IsNullOrEmpty(s) && s.Length == 8 && hasOneUpper && hasDigits;
    }
