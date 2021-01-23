    char[] chars = string.ToCharArray();
    char[] destchars = new char[chars.Length * 2];
    for(int i = 0, j = 0; i < chars.Length; ++i, j += 2)
    {
       destchars[j] = chars[i];
       destchars[j+1] = chars[i];
    }
    string newstr = new string(destchars);
