    public enum TestEnum
    {
	    Value1,
	    Value2
    }
    public class TestClass
    {
	    public TestEnum TestProp { get; set; }
    }
    void Main()
    {
        var exampleJson = "{TestProp:'Value2'}";
	    var deserializedObj = JsonConvert.DeserializeObject<TestClass>(exampleJson);
	    Console.WriteLine(deserializedObj.TestProp);
    }
