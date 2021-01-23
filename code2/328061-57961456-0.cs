    public static int GetDamerauLevenshteinDistance(string s, string t)
    {
        if (string.IsNullOrEmpty(s))
        {
            throw new ArgumentNullException(s, "String Cannot Be Null Or Empty");
        }
        if (string.IsNullOrEmpty(t))
        {
            throw new ArgumentNullException(t, "String Cannot Be Null Or Empty");
        }
        int n = s.Length; // length of s
        int m = t.Length; // length of t
        if (n == 0)
        {
            return m;
        }
        if (m == 0)
        {
            return n;
        }
        int[] p = new int[n + 1]; //'previous' cost array, horizontally
        int[] d = new int[n + 1]; // cost array, horizontally
        // indexes into strings s and t
        int i; // iterates through s
        int j; // iterates through t
        for (i = 0; i <= n; i++)
        {
            p[i] = i;
        }
        for (j = 1; j <= m; j++)
        {
            char tJ = t[j - 1]; // jth character of t
            d[0] = j;
            for (i = 1; i <= n; i++)
            {
                int cost = s[i - 1] == tJ ? 0 : 1; // cost
                // minimum of cell to the left+1, to the top+1, diagonally left and up +cost				
                d[i] = Math.Min(Math.Min(d[i - 1] + 1, p[i] + 1), p[i - 1] + cost);
            }
            // copy current distance counts to 'previous row' distance counts
            int[] dPlaceholder = p; //placeholder to assist in swapping p and d
            p = d;
            d = dPlaceholder;
        }
        // our last action in the above loop was to switch d and p, so p now 
        // actually has the most recent cost counts
        return p[n];
    }
