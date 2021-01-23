    public string BuildQuery(string[] columnNames, string tableName)
    {
    string query = string.Empty;
    
    query = "SELECT ";
    foreach(string str in columnNames)
    query += str + ", ";
    query = query.Substring(0, query.Length - 1);
    query += " FROM " + tableName;
    
    return query;
    }
