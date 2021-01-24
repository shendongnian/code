`
[JsonObject(MemberSerialization.OptIn)]
public class MyClass
{
    [JsonProperty]
    public string NotIgnored { get; set; }
    public string Line2 { get; set; }
    public string Line3 { get; set; }
}
`
More info here: [Newtonsoft Documentation][1]
  [1]: https://www.newtonsoft.com/json/help/html/JsonObjectAttributeOptIn.htm
