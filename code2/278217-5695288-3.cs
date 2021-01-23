private static string CreateInsertSql(string table, 
                                      IDictionary&lt;string, string&gt; parameterMap)
{
    var keys = parameterMap.Keys.ToList();
    // ToList() LINQ extension method used because order is NOT
    // guaranteed with every implementation of IDictionary&lt;TKey, TValue&gt;
    var sql = new StringBuilder("INSERT INTO ").Append(table).Append("(");
    for (var i = 0; i &lt; keys.Count; i++)
    {
        sql.Append(keys[i]);
        if (i &lt; keys.Count - 1)
            sql.Append(", ");
    }
    sql.Append(") VALUES(");
    for (var i = 0; i &lt; keys.Count; i++)
    {
        sql.Append('?').Append(keys[i]);
        if (i &lt; keys.Count - 1)
            sql.Append(", ");
    }
    return sql.Append(")").ToString();
}
private static void SqlInsert(string table, IDictionary&lt;string, string&gt; parameterMap)
{
    using (var connection = AcquireConnection())
    {
        connection.Open();
        using (var command = connection.CreateCommand())
        {
            command.Connection = connection;
            command.CommandText = CreateInsertSql(table, parameterMap);
            foreach (var pair in parameterMap)
                command.Parameters.Add(pair.Key, pair.Value);
            command.ExecuteNonQuery();
        }
    }
}
