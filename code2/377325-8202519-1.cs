    [DataContract]
    public class PersonCollection
    {
    	[DataMember(Name = "people")]
    	public IEnumerable<Person> People { get; set; }
    }
    
    [DataContract]
    public class Person
    {
    	[DataMember]
    	public string ID { get; set; }
    	
    	[DataMember]
    	public string Name { get; set; }
    	
    	[DataMember]
    	public string Age { get; set; }
    }
