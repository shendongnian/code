    if (MeetsSizeRequirementsOrIsNull(filename, size))
    {        
    }
    
    private static bool MeetsSizeRequirementsOrIsNull(string filename, string size)
    {
        List<string> sizes = new List<string>() { "..." };
    
        return string.IsNullOrEmpty(filename) || sizes.Contains(size.ToLower())
    }
