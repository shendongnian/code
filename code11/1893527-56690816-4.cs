    [DataContract]
    class Person
    {
    	[DataMember]
    	public string Name { get; set; }
    
    	[DataMember(EmitDefaultValue = false)]
    	public Gender Gender { get; set; }
    }
    
    
    void Main()
    {
    	var json = "{\"Name\": \"XXX\"}";
    	var ser = new DataContractJsonSerializer(typeof(Person));
    	var obj = ser.ReadObject(new MemoryStream(Encoding.UTF8.GetBytes(json)));
    	obj.Dump(); // Person { Name = "XXX", Gender = Male }
    }
