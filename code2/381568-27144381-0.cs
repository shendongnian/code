    public static bool ImportRowIfNotExists(DataTable dataTable, DataRow dataRow, string keyColumnName)
    {
        string selectStatement = string.Format("{0} = '{1}'", keyColumnName, dataRow[keyColumnName]);
        DataRow[] rows = dataTable.Select(selectStatement);
        if (rows.Length == 0)
        {
            dataTable.ImportRow(dataRow);
            return true;
        }
        else
        {
            return false;
        }
    }
