    [DataContract]
    class Person
    {
    	[DataMember]
    	public string Name { get; set; }
    
    	[IgnoreDataMember]
    	public Gender Gender
    	{
    		get
    		{
    			if (GenderValue.GetType() == typeof(string))
    			{
    				Enum.TryParse((string)GenderValue, out Gender result);
    				return result;
    			}
    			return (Gender)Convert.ToInt32(GenderValue);
    		}
    		set
    		{
    			GenderValue = value;
    		}
    	}
    
    	[DataMember(Name = "Gender", EmitDefaultValue = false)]
    	private object GenderValue { get; set; }
    }
    
    
    void Main()
    {
    	var json = "{\"Name\": \"XXX\", \"Gender\": \"\"}";
    	var ser = new DataContractJsonSerializer(typeof(Person));
    	var obj = ser.ReadObject(new MemoryStream(Encoding.UTF8.GetBytes(json)));
    	obj.Dump(); // Person { Name = "XXX", Gender = Male }
    }
