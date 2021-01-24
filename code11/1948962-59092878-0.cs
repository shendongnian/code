    public class MyComplexObject
    {
	[FromQuery(Name = "Id")]
    public string Id { get; set; }
	[FromQuery(Name = "Level")]
    public int Level { get; set; }
	[FromQuery(Name = "MyEnum")]
    public Enum MyEnum { get; set; }
    }
