public class Amount
{
    [JsonProperty("currency")]
    public string Currency { get; set; }
    [JsonProperty("value")]
    public int Value { get; set; }
}
public class RootObject
{
    [JsonProperty("amount")]
    public Amount Amount { get; set; }
}
**Use this for Deserialization**
var amount = JsonConvert.DeserializeObject<RootObject>(json)
**Easy way to find the classes**
I have found [www.json2csharp.com ](http://json2csharp.com/) to be a pretty good resource. Whenever in doubt, copy / paste your json there to get all the classes you need. Copy them in your project and deserialize to RootObject. If your JSON is invalid, you'll find out whats wrong there as well.
