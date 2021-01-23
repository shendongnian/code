     public class ReadingEntity : TableEntity
    {
        public static string KeyLength = "000000000000000000000";
        public ReadingEntity(string partitionId, int keyId)
        {
            this.PartitionKey = partitionId;
            this.RowKey = keyId.ToString(KeyLength); ;
           
            
        }
        public ReadingEntity()
        {
        }
}
            public IList<ReadingEntity> Get(string partitionName,int date,int enddate)
        {
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();
            // Create the CloudTable object that represents the "people" table.
            CloudTable table = tableClient.GetTableReference("Record");
            // Construct the query operation for all customer entities where PartitionKey="Smith".
            TableQuery<ReadingEntity> query = new TableQuery<ReadingEntity>().Where(TableQuery.CombineFilters(
        TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, partitionName),
        TableOperators.And,TableQuery.CombineFilters(
        TableQuery.GenerateFilterCondition("RowKey", QueryComparisons.LessThan, enddate.ToString(ReadingEntity.KeyLength)), TableOperators.And,
        TableQuery.GenerateFilterCondition("RowKey", QueryComparisons.GreaterThanOrEqual, date.ToString(ReadingEntity.KeyLength)))));
            return table.ExecuteQuery(query).ToList();
        }
