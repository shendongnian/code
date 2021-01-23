    public static string Cutstring(string s, int min, int max)
    {
        string res = "";
        int runto = s.Length;
        if (s.Length > max) runto = max;
        for (int i = 0; i < runto; i++)
        {
            if (i > min)
            {
                if ((s[i] == ' ') || (s[i] == '_')|| (s[i] == '-'))
                {
                    break;
                }
            }
            res += s[i];
        }
        if (s.Length > max) res += "...";
        return res;
    }
