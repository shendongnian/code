    public bool Check(string s)
    {   
	    bool hasUpper = s.Any(c => char.IsUpper(c));
	    bool hasDigit = s.Any(c => char.IsDigit(c));        
        
        return hasUpper && hasDigit && s.Length >= 8;
    }
