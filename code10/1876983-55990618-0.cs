    HashSet<string> record = new HashSet<string>();
    foreach (var row in dtCSV.Rows)
    {
        StringBuilder textEditor= new StringBuilder();
        foreach (string col in columns)
        {
            textEditor.AppendFormat("[{0}={1}]", col, row[col].ToString());
        }
        if (!record.Add(textEditor.ToString())
        {
        }
    }
