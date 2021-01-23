    public class SomeClass
    {
    	public BsonObjectId Id { get; set; }
    	
    	[BsonElement("dt")]
    	public DateTime SomeReallyLongDateTimePropertyName { get; set; }
    }
