    public class TextEntity : TableEntity
    {
        public TextEntity(string partitionKey, string rowKey)
        {
            this.PartitionKey = partitionKey;
            this.RowKey = rowKey;
        }
    
        public TextEntity() { }
    
        public string Text { get; set; }
    }
