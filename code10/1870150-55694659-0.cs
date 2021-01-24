    List<string> ph = new List<string>();
    int count = 0;
    foreach(string s in searchTerm)
    {
        ph.Add($"MySqlField LIKE '%{{{count}}}%'");
        count++;
    }
    if(count > 0)
        query = query + " WHERE " + string.Join(" OR ", ph);
    var results = this.MySqlTable.FromSql(query, searchTerm.ToArray());
