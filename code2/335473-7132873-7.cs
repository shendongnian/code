        public void BulkLoadData(IDataReader reader, string tableName)
        {
            using (SqlConnection cnn = new SqlConnection(cnnString))
            {
                SqlBulkCopy copy = new SqlBulkCopy(cnn);
                copy.DestinationTableName = tableName;
                copy.BatchSize = 10000;
                cnn.Open();
                copy.WriteToServer(reader);
            }
        }
