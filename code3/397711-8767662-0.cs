    public void Bulk(String connectionString, DataTable data, String destinationTable)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            using (SqlBulkCopy bulkCopy =
                new SqlBulkCopy
                (
                connection,
                SqlBulkCopyOptions.TableLock |
                SqlBulkCopyOptions.FireTriggers |
                SqlBulkCopyOptions.UseInternalTransaction,
                null
                ))
            {
                bulkCopy.BatchSize = data.Rows.Count;
                bulkCopy.DestinationTableName = String.Format("[{0}]", destinationTable);
                connection.Open();
                bulkCopy.WriteToServer(data);
            }
        }
    }
