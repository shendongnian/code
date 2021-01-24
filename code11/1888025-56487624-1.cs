     public class TableStorageClass
        {
            public TableStorageClass()
            {
    
            }
            public TableStorageClass(DynamicTableEntity entity)
            {
                PartitionKey = entity.PartitionKey;
                RowKey = entity.RowKey;
    
            }
    
            public string PartitionKey { get; set; }
            public string RowKey { get; set; }
    
    
        }
