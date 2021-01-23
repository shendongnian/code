private static string CreateInsertSql(string table, 
                                      IDictionary&lt;string, string&gt; parameterMap)
{
    var list = parameterMap.ToList();
    var sql = new StringBuilder("INSERT INTO ").Append(table).Append("(");
    for (var i = 0; i &lt; list.Count; i++)
    {
        sql.Append(list[i].Key);
        if (i &lt; list.Count - 1)
            sql.Append(", ");
    }
    sql.Append(") VALUES(");
    for (var i = 0; i &lt; list.Count; i++)
    {
        sql.Append('?').Append(list[i].Key);
        if (i &lt; list.Count - 1)
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
            foreach (var key in parameterMap.Keys)
                command.Parameters.Add(key, parameterMap[key]);
            command.ExecuteNonQuery();
        }
    }
}
