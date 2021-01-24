    public class MyClass
    {
    	[JsonProperty(PropertyName = "{}")]
    	public string Brackets { get; set; }
    }
    // Usage:
    var obj = new MyClass { Brackets = "" };
    string result = JsonConvert.SerializeObject(obj);
