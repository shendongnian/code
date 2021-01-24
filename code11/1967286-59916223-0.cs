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
and you deserialize to the parent object. 
var amount = JsonConvert.DeserializeObject<RootObject>(json)
