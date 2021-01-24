    public bool Check(string s)
    {
        // It would be worth to check for null
        if(s == null)
           throw new ArgumentNullException(nameof(s));
        // because of the && all criteria must be true
        return 
            s.Length == 8                  // is the length 8?
            && s.Count(Char.IsUpper) == 1  // the must be one uppercase character? (the trick is to execute the IsUpper for each character)
            && s.Any(Char.IsDigit);        // Does it contain any digit? (same here)
    }
