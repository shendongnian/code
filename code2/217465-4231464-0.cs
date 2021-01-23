    ...
    StringBuilder sb = new StringBuilder();
    for( int i = 0; i < strings.Length; i++)
    {
        sb.WriteLine("{0}<br />", strings[i]);
    }
    return sb.ToString();
