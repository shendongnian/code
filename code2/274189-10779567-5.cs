    private static void ExecuteProcedure(bool useDataTable, 
                                         string connectionString, 
                                         IEnumerable<long> ids) 
    {
        using (SqlConnection connection = new SqlConnection(connectionString)) 
        {
            connection.Open();
            using (SqlCommand command = connection.CreateCommand()) 
            {
                command.CommandText = "dbo.procMergePageView";
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter parameter;
                if (useDataTable) {
                    parameter = command.Parameters
                                  .AddWithValue("@Display", CreateDataTable(ids));
                }
                else 
                {
                    parameter = command.Parameters
                                  .AddWithValue("@Display", CreateSqlDataRecords(ids));
                }
                parameter.SqlDbType = SqlDbType.Structured;
                parameter.TypeName = "dbo.PageViewTableType";
                command.ExecuteNonQuery();
            }
        }
    }
    private static DataTable CreateDataTable(IEnumerable<long> ids) 
    {
        DataTable table = new DataTable();
        table.Columns.Add("ID", typeof(long));
        foreach (long id in ids) 
        {
            table.Rows.Add(id);
        }
        return table;
    }
    private static IEnumerable<SqlDataRecord> CreateSqlDataRecords(IEnumerable<long> ids) 
    {
        SqlMetaData[] metaData = new SqlMetaData[1];
        metaData[0] = new SqlMetaData("ID", SqlDbType.BigInt);
        SqlDataRecord record = new SqlDataRecord(metaData);
        foreach (long id in ids) 
        {
            record.SetInt64(0, id);
            yield return record;
        }
    }
