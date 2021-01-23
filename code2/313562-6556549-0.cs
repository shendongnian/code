    public class TableSpec<T>
    {
      public readonly string name;
      public TableSpec(string name) { this.name = name; }
    }
    public static readonly TableSpec<Sequence> SequenceTableSpec = new TableSpec<Sequence>("Sequences");
    public static readonly TableSpec<Topic> TopicTableSpec = new TableSpec<Topic>("Topics");
    public static readonly TableSpec<Test> TestTableSpec = new TableSpec<Test>("Tests");
    public static IAzureTable<T> GetTable<T>(TableSpec<T> spec, string datastoreValue)
    {
      var table = new AzureTable<T>(GetStorageAccount(datastoreValue), spec.name);
      return table;
    }
