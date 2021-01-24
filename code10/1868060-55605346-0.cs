    public class TableStorage
    {
        public class MyPoco : TableEntity
        {
            public string Text { get; set; }
        }
    
        [FunctionName("TableInput")]
        public static void TableInput(
            [QueueTrigger("table-items")] string input, 
            [Table("MyTable", "MyPartition")] IQueryable<MyPoco> pocos, 
            ILogger log)
        {
            foreach (MyPoco poco in pocos)
            {
                log.LogInformation($"PK={poco.PartitionKey}, RK={poco.RowKey}, Text={poco.Text}");
            }
        }
    }
