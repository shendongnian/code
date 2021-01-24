	void Main()
	{
		var myJson = "[{\"data\": [50291, 7410, 2013, 2013, 524, 201], \"name\": \"project1\"}, {\"data\": [50291, 7410, 2013, 2013, 524, 201], \"name\": \"project2\"}]";
		
		var myObject = Newtonsoft.Json.JsonConvert.DeserializeObject<List<MyData>>(myJson);
		
		var myJsonAgain = Newtonsoft.Json.JsonConvert.SerializeObject(myObject);	
	}
	
	public class MyData
	{
		public List<Int32> Data { get; set; }
		public String Name { get;set; }
	}
