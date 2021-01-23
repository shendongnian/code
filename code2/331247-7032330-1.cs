    public static int MatchingFunction(string s1, string s2, bool duplicate, bool keySensitive)
    {
        if (!keySensitive)
        {
            s1 = s1.ToLower();
            s2 = s2.ToLower();
        }
    
        List<string> ls1 = null;
        s2 = s2.Trim();
    
        if (duplicate)
        {
            ls1 = s1.Trim().Split(' ').ToList();
        }
        else
        {
            ls1 = new List<string>();
            string[] as1 = s1.Trim().Split(' ');
            foreach (string s in as1)
                if (!ls1.Contains(s))
                    ls1.Add(s);
    
            string[] as2 = s2.Trim().Split(' ');
            s2 = string.Empty;
            foreach (string s in as2)
                if (!s2.Contains(s))
                    s2 = string.Format("{0} {1}", s2, s);
        }
    
    
        int has = 0;
        s2 = string.Format("@{0}@", s2.Replace(' ', '@');
        foreach (string s in ls1)
            has += s2.Contains(string.Format("@{0}@", s)) ? 1 : 0;
    
        return (has * 100 / ls1.Count());
    }
        
    
    string s1 =  " I have a black car";
    string s2 = "I have a car that is small";
    
    int p = MatchingFunction(s1, s2, false, false);
