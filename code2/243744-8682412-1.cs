    // see: http://stackoverflow.com/questions/87747/how-do-you-determine-what-sql-tables-have-an-identity-column-programatically
    private static string GetIdentityColumnName(SqlConnection sqlConnection, Tuple<string, string> table)
    {
        string columnName = string.Empty;
        const string commandString =
             "select TABLE_SCHEMA, TABLE_NAME, COLUMN_NAME from INFORMATION_SCHEMA.COLUMNS "
           + "where TABLE_SCHEMA = 'dbo' and COLUMNPROPERTY(object_id(TABLE_NAME), COLUMN_NAME, 'IsIdentity') = 1 "
           + "order by TABLE_NAME";
        DataSet dataSet = new DataSet();
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
        sqlDataAdapter.SelectCommand = new SqlCommand(commandString, sqlConnection);
        sqlDataAdapter.Fill(dataSet);
        if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                // compare name first
                if (string.Compare(table.Item2, row[1] as string, true) == 0)
                {
                    // if the schema as specified, we need to match it, too
                    if (string.IsNullOrWhiteSpace(table.Item1) || string.Compare(table.Item1, row[0] as string) == 0)
                    {
                        columnName = row[2] as string;
                        break;
                    }
                }
            }
        }
        return columnName;
    }
