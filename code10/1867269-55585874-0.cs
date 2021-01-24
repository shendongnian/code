    var pool = new SingleNodeConnectionPool(new Uri("http://localhost:9200"));
    var settings = new ConnectionSettings(pool)
        .DefaultIndex("example")
		.DefaultTypeName("_doc");
    var client = new ElasticClient(settings);
    public class HashObject
    {
    	public int DataRecordId { get; set; }
    	public DateTime TimeStamp { get; set; }
    }
