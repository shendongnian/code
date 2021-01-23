    StringBuilder sb = new StringBuilder(str.Length);
    foreach(char ch in str)
    {
        if (0x20 <= ch && ch <= 0x7F)
        {
            sb.Append(ch)
        }
    }
    
    string result = sb.ToString();
