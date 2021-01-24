public class Request
{
  public List<BarContainer> foo {get; set;}
  // Your constructor should initialize this list.
}
public class BarContainer
{
  public Bar bar {get; set;}
}
public class Bar
{
  [JsonProperty("name")]
  public string Name { get; set;}
  [JsonProperty("firstLetter")]
  public string FirstLetter { get; set;}
}
NOTE: the deserialization is case sensitive, so you need to use the exacty names in the JSON, `bar`, `foo`, `name`, `firstLetter` or use attributes or configuration to support the different casing of the property names:
- [Serialization attributes][1]
- [JsonPropertyAttribute name][2]
  [1]: https://www.newtonsoft.com/json/help/html/SerializationAttributes.htm
  [2]: https://www.newtonsoft.com/json/help/html/JsonPropertyName.htm
