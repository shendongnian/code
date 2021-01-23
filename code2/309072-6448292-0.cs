    public string Combine(List<string> names)
    {
        if (names == null || names.Count == 0)
        {
            return string.Empty;
        }
        
        var sb = new StringBuilder();
        sb.Append(names[0]);
        
        //Handle Special Case of 2 names
        if (names.Count == 2)
        {
            sb.Append(" and " + names[1])
            return sb.ToString();
        }
        
        for (int i = 1; i < names.Count; i++)          
        {
            if (i == (names.Count -1))
            { 
                sb.Append(", and " + names[i]);
            }
            else
            {
                sb.Append(", " + names[i]);
            }
        }
                
        return sb.ToString(); 
    }
