    class Entity : TableServiceEntity
    {
        public string Text { get; set; }
        public Entity() { }
        public Entity(string rowkey) : base(string.Empty, rowkey) { }
    }
    class Program
    {
        static void Update(CloudStorageAccount account)
        {
            var ctx = account.CreateCloudTableClient().GetDataServiceContext();
            var entity = new Entity("foo") { Text = "bar" };
            ctx.AttachTo("testtable", entity, "*");
            ctx.UpdateObject(entity);
            ctx.SaveChangesWithRetries();
        }
        static void Main(string[] args)
        {
            var account = CloudStorageAccount.Parse(args[0]);
            var tables = account.CreateCloudTableClient();
            tables.CreateTableIfNotExist("testtable");
            var ctx = tables.GetDataServiceContext();
            try { Update(account); } catch (Exception e) { Console.WriteLine("Exception (as expected): " + e.Message); }
            ctx.AddObject("testtable", new Entity("foo") { Text = "foo" });
            ctx.SaveChangesWithRetries();
            try { Update(account); } catch (Exception e) { Console.WriteLine("Unexpected exception: " + e.Message); }
            Console.WriteLine("Now text is: " + tables.GetDataServiceContext().CreateQuery<Entity>("testtable").Where(e => e.PartitionKey == string.Empty && e.RowKey == "foo").Single().Text);
            tables.DeleteTableIfExist("testtable");
        }
    }
