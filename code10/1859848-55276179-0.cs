csharp
content.Where(e => e.Value != null).ToDictionary(e => e.Key, e => e.Value)
Alternativly you could use a class instead of a Dictionary and use json.net's [`JsonProperty.NullValueHandling`](https://www.newtonsoft.com/json/help/html/P_Newtonsoft_Json_Serialization_JsonProperty_NullValueHandling.htm) like so:
csharp
public class DataModel
{
    [JsonProperty("limit")]
    public int Limit { get; set; }
    [JsonProperty("offset")]
    public int Offset { get; set; }
    [JsonProperty("sort", NullValueHandling = NullValueHandling.Ignore)]
    public object Sort { get; set; }
    [JsonProperty("order", NullValueHandling = NullValueHandling.Ignore)]
    public object Order { get; set; }
}
