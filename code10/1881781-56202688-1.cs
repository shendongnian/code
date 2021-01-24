[DataContract]
public class TestSubObject
{
    [DataMember]
    public string Property { get; private set; } = "Bar";
}
[DataContract]
public class TestObject
{
    [DataMember]
    public TestSubObject Sub { get; set; }
    [DataMember]
    public string Property { get; set; }
}
Output:
{
  "Property": "Foo",
  "Sub": {
    "Property": "Bar"
  }
}
