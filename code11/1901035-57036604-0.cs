public class Program
    {
        public static void Main()
        {
            var cluster = Cluster.Builder().AddContactPoint("127.0.0.1").Build();
            var session = cluster.Connect();
            session.CreateKeyspaceIfNotExists("testks");
            session.ChangeKeyspace("testks");
            session.Execute($"CREATE TYPE IF NOT EXISTS testks.{nameof(LogParamsCUDT)} (Key text, ValueString text);");
            session.UserDefinedTypes.Define(UdtMap.For<LogParamsCUDT>($"{nameof(LogParamsCUDT)}", "testks"));
            var table = new Table<Log>(session);
            table.CreateIfNotExists();
            table.Insert(new Log
            {
                LoggingLevel = 1,
                UserId = Guid.NewGuid(),
                TimeZone = "123",
                Text = "123",
                LogParams = new List<LogParamsCUDT>
                {
                    new LogParamsCUDT
                    {
                        Key = "123",
                        ValueString = "321"
                    }
                }
            }).Execute();
            var result = table.First(l => l.Text == "123").Execute();
            Console.WriteLine(JsonConvert.SerializeObject(result));
            Console.ReadLine();
            table.Where(l => l.Text == "123").Delete().Execute();
        }
    }
    
    public class Log
    {
        public int LoggingLevel { get; set; }
        public Guid UserId { get; set; }
        public string TimeZone { get; set; }
        [Cassandra.Mapping.Attributes.PartitionKey]
        public string Text { get; set; }
        [Frozen]
        public IEnumerable<LogParamsCUDT> LogParams { get; set; }
    }
    public class LogParamsCUDT
    {
        public string Key { get; set; }
        public string ValueString { get; set; }
    }
Note that I had to add the `PartitionKey` attribute or else it wouldn't run.
Here is the CQL statement that it generated:
CREATE TABLE Log (
    LoggingLevel int, 
    UserId uuid, 
    TimeZone text, 
    Text text, 
    LogParams frozen<list<"testks"."logparamscudt">>, 
    PRIMARY KEY (Text)
)
If I remove the `Frozen` attribute, then this error occurs: `Cassandra.InvalidQueryException: 'Non-frozen collections are not allowed inside collections: list<testks.logparamscudt>'`.
If your intention is to have a column like this `LogParams frozen<list<"testks"."logparamscudt">>` then the `Frozen` attribute will work. If instead you want only the UDT to be frozen, i.e., `LogParams list<frozen<"testks"."logparamscudt">>`, then AFAIK the `Frozen` attribute won't work and you can't rely on the driver to generate the `CREATE` statement for you.
All my testing was done against cassandra `3.0.18` using the latest C# driver (`3.10.1`).
