    [DataContract]
    public class MyModel: ISpecificRecord
    {
	    [DataMember]
	    public string Id;
	    [DataMember]
    	public enumP Type;
    	[DataMember]
    	public long Timestamp;
    	public Dictionary<string, string> Context;
    	public static Schema _SCHEMA = Avro.Schema.Parse(@"...");
 
    	public virtual Schema Schema
	    {
		    get
		    {
		    	return Position._SCHEMA;
	    	}
	    }
    	public object Get(int fieldPos)
    	{
    		switch (fieldPos)
    		{
    			case 0: return this.Id;
    			case 1: return this.Timestamp;
    			case 2: return this.Type;                
    			case 3: return this.Context;
    			default: throw new AvroRuntimeException("Bad index " + fieldPos + " in Get()");
	    	};
    	}
    	public void Put(int fieldPos, object fieldValue)
    	{
    		switch (fieldPos)
    		{
	    		case 0: this.Id = (System.String)fieldValue; break;
	    		case 1: this.Timestamp = (System.Int64)fieldValue; break;
	    		case 2: this.Type = (enumP)fieldValue; break;                
	    		case 3: this.Context = (Dictionary<string,string>)fieldValue; break;
	    		default: throw new AvroRuntimeException("Bad index " + fieldPos + " in Put()");
	    	};
	    }
    }
    [DataContract]
    public enum enumP
    {
	    ONE, TWO, THREE
    }
