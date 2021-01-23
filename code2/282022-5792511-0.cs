    public void BulkLoadToTemp(DataTable dt, String tableName, int bulkLoadBatchSize)
        {
            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(this._connection))
            {
                bulkCopy.DestinationTableName = tableName;
                bulkCopy.BulkCopyTimeout = 120;
                bulkCopy.BatchSize = bulkLoadBatchSize;
                bulkCopy.WriteToServer(dt);
                bulkCopy.Close();
            }            
        }
