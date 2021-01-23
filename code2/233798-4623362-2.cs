    // ...
    string[] columns = r.Split(new char[] { '\t' },  StringSplitOptions.RemoveEmptyEntries);
    if (tab.Columns.Count == 0)
    {
        for(int i = 0; i < columns.Length; i++)
            tab.Columns.Add("Column" + (i + 1));
    }
    
    if (columns.Length <= tab.Columns.Count)
    {
    // ... 
