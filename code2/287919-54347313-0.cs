    // at some point in my calling code, I will call:
    var myDataTable = CreateMyDataTable();
    myDataTable.Rows.Add(Guid.NewGuid,tableHeaderId,theName,theValue); // e.g. - need this call for each row to insert
    var efConnectionString = ConfigurationManager.ConnectionStrings["MyWebConfigEfConnection"].ConnectionString;
    var efConnectionStringBuilder = new EntityConnectionStringBuilder(efConnectionString);
    var connectionString = efConnectionStringBuilder.ProviderConnectionString;
    BulkInsert(connectionString, myDataTable);
    private DataTable CreateMyDataTable()
    {
        var myDataTable = new DataTable { TableName = "MyTable"};
	// this table has an identity column - don't need to specify that
        myDataTable.Columns.Add("MyTableRecordGuid", typeof(Guid));
        myDataTable.Columns.Add("MyTableHeaderId", typeof(int));
        myDataTable.Columns.Add("ColumnName", typeof(string));
        myDataTable.Columns.Add("ColumnValue", typeof(string));
        return myDataTable;
    }
    private void BulkInsert(string connectionString, DataTable dataTable)
    {
        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();
            SqlTransaction transaction = null;
            try
            {
                transaction = connection.BeginTransaction();
                using (var sqlBulkCopy = new SqlBulkCopy(connection, SqlBulkCopyOptions.TableLock, transaction))
                {
                    sqlBulkCopy.DestinationTableName = dataTable.TableName;
                    foreach (DataColumn column in dataTable.Columns) {
                        sqlBulkCopy.ColumnMappings.Add(column.ColumnName, column.ColumnName);
                    }
                    sqlBulkCopy.WriteToServer(dataTable);
                }
                transaction.Commit();
            }
            catch (Exception)
            {
                transaction?.Rollback();
                throw;
            }
        }
    }
