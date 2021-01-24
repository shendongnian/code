    // Example data
    var valuesToDelete = new List<string> { "1", "2", "4" };
    sqliteCommand.CommandText = @"delete from [test_table] where col1 in(" + string.Join(",", Enumerable.Range(0, valuesToDelete.Count).Select(z => "@para" + z)) + ")";
    for (var i = 0; i < valuesToDelete.Count; i++)
    {
        sqliteCommand.Parameters.Add(new SqliteParameter("@para" + i, valuesToDelete[i]));
    }
    sqliteCommand.ExecuteNonQuery();
