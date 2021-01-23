    public string SafeGetString(DataRow row, string columnName)
    {
        if(row[columnName] != null && row[columnName] != DBNull.Value)
        {
            return row[ColumName].ToString();
        }
        return string.Empty;
    }
