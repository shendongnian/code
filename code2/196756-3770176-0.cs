    string GetLongestCommonPrefix(IEnumerable<string> items)
    {
        return items.Aggregate(default(string), GetLongestCommonPrefix);
    }
    
    string GetLongestCommonPrefix(string s1, string s2)
    {
        if (s1 == null || s2 == null)
            return s1 ?? s2;
    
        int n = Math.Min(s1.Length, s2.Length);
        int i;
        for (i = 0; i < n; i++)
        {
            if (s1[i] != s2[i])
                break;
        }
        return s1.Substring(0, i);
    }
