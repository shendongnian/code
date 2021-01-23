    List<string> firstNames = new List<string>();
    firstNames.Add("John");
    firstNames.Add("Mary");
    firstNames.Add("Jane");
    
    StringBuilder names = new StringBuilder();
    for (int i = 0; i < firstNames.Count; i++)
    {
        if((i-1) == firstNames.Count && names.length > 0)
             names.AppendFormat(" and {0}", names[i]);
        else if(names.length > 0)
             names.AppendFormat(", {0}", names[i]);    
    }
    return names.ToString();
