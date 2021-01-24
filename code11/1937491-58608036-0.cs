    public static string[] Compare(List<string[]> A)
    {
        string result = string.Empty;
        foreach(string s in A[0])
        {
            if(A[1].Contains(s))
            {
                if(result==string.Empty)
                {
                    result += s;
                }
                else
                {
                    result += "," + s;
                }
            }
        }
        return result.Split(',');
    }
