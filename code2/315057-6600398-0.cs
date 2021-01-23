     public class Template : TableServiceEntity
        {
            public Template()
            {
                this.PartitionKey = string.Empty;
                this.RowKey = Guid.NewGuid().ToString();
            }(...)
