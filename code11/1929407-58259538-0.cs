    public bool Check(string s)
    {
        bool retVal = false;
    
        if (s.Length == 8 && s.Any(char.IsUpper) && s.Any(char.IsDigit))
        {
            retVal = true;
        }
    
        return retVal;
    }
