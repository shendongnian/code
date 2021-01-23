    static string Combine(List<string> names)
    {
        var sb = new StringBuilder();
        for (int i = 0; i < names.Count; i++)
        {
            if (i == 0) //at start of a list
                {}
            else if (i < names.Count - 1) //in middle of list
                sb.Append(", ");
            else if( names.Count == 2 ) //at end of a list with 2 elements
                sb.Append(" and ");
            else //at end of a list with 3 or more elements
                sb.Append(", and ");
            sb.Append(names[i]);
        }
        return sb.ToString();
    }
