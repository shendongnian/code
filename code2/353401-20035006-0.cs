    MySqlDataReader resultSet = cmd.ExecuteReader();
    dt.Columns.Clear();
    for (int i = 0; i < resultSet.FieldCount; i++)
    {
        dt.Columns.Add(resultSet.GetName(i));
    }
    dt.Load(resultSet);
