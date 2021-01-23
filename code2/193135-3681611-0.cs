    static string InvertCasing(string s)
    {
        char[] c = s.ToCharArray();
        char[] cUpper = s.ToUpper().ToCharArray();
        char[] cLower = s.ToLower().ToCharArray();
    
        for (int i = 0; i < c.Length; i++)
        {
            if (c[i] == cUpper[i])
            {
                c[i] = cLower[i];
            }
            else
            {
                c[i] = cUpper[i];
            }
        }
    
        return new string(c);
    }
