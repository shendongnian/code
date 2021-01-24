    public bool Check(string s)
    {   
	    bool hasUpper = password.Any(c => char.IsUpper(c));
	    bool hasDigit = password.Any(c => char.IsDigit(c));        
        
        return hasUpper && hasDigit && s.Length >= 8;
    }
