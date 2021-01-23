    public virtual void FillDatabaseTable(DataTable table)
    {
        var connection = _dbContextLocator.Current.Database.Connection;
        connection.Open();
        SetIdentityInsert(table, connection, true);
        FillDatabaseRecords(table, connection);
        SetIdentityInsert(table, connection, false);
        connection.Close();
    }
    private void FillDatabaseRecords(DataTable table, DbConnection connection)
    {
        var command = GetNewCommand();
        command.Connection = connection;
        var rawCommandText = string.Format("insert into {0} values ({1})", table.TableName, "{0}");
        foreach (var row in table.AsEnumerable())
            FillDatabaseRecord(row, command, rawCommandText);
    }
    private void FillDatabaseRecord(DataRow row, DbCommand command, string rawCommandText)
    {
        var values = row.ItemArray.Select(i => ItemToSqlFormattedValue(i));
        var valueList = string.Join(", ", values);
        command.CommandText = string.Format(rawCommandText, valueList);
        command.ExecuteNonQuery();
    }
    private string ItemToSqlFormattedValue(object item)
    {
        if (item is System.DBNull)
            return "NULL";
        else if (item is bool)
            return (bool)item ? "1" : "0";
        else if (item is string)
            return string.Format("'{0}'", ((string)item).Replace("'", "''"));
        else if (item is DateTime)
            return string.Format("'{0}'", ((DateTime)item).ToString("yyyy-MM-dd HH:mm:ss"));
        else
            return item.ToString();
    }
    private void SetIdentityInsert(DataTable table, DbConnection connection, bool enable)
    {
        var command = GetNewCommand();
        command.Connection = connection;
        command.CommandText = string.Format(
            "set IDENTITY_INSERT {0} {1}",
            table.TableName,
            enable ? "on" : "off");
        command.ExecuteNonQuery();
    }
