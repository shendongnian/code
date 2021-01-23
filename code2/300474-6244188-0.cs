    static string PathDifference(string path1, string path2)
    {
        int c = 0;  //index up to which the paths are the same
        int d = -1; //index of trailing slash for the portion where the paths are the same
    
        while (c < path1.Length && c < path2.Length)
        {
            if (char.ToLowerInvariant(path1[c]) != char.ToLowerInvariant(path2[c]))
            {
                break;
            }
    
            if (path1[c] == '\\')
            {
                d = c;
            }
    
            c++;
        }
    
        if (c == 0)
        {
            return path2;
        }
    
        if (c == path1.Length && c == path2.Length)
        {
            return string.Empty;
        }
    
    
        System.Text.StringBuilder builder = new System.Text.StringBuilder();
                
        while (c < path1.Length)
        {
            if (path1[c] == '\\')
            {
                builder.Append(@"..\");
            }
            c++;
        }
    
        if (builder.Length == 0 && path2.Length - 1 == d)
        {
            return @".\";
        }
    
        return builder.ToString() + path2.Substring(d + 1);
    }
