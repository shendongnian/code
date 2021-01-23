    var sb = new StringBuilder();
    for(int i = 0; i < items.Count; i++)
    {
        if(i != 0)
        {
            if(i == items.Count-1) sb.Append(" and ");
            else sb.Append(", ");
        }
        sb.Append(items[i]);
    }
    return sb.ToString();
