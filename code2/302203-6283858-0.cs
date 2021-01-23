    var s = @"C:\Users\Admin\Documents\report2011.docx: My Report 2011";
    var i = GetNthIndex(s,':',2);
    var result = s.Substring(i+1);
    
    
    public int GetNthIndex(string s, char t, int n)
    {
        int count = 0;
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == t)
            {
                count++;
                if (count == n)
                {
                    return i;
                }
            }
        }
        return -1;
    }
