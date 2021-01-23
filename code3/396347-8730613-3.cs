    // Generates a random code of given length. If it is not
    // in the set, adds it and returns the code. If it is
    // already in the set, tries again. 
    static string AddUniqueCode(int length, HashSet<string> set)
    {
        while(true)
        {
            string code = string.Join(null, Digits().Take(length));
            if (set.Add(code))
                return code;
        }
    }    
