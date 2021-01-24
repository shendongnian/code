cs
using Newtonsoft.Json;
public class Item
{
    public int Id { get; set; }
    
    [JsonProperty("ServiceName")]
    public string ItemName { get; set; }
}
  [1]: https://www.newtonsoft.com/json/help/html/T_Newtonsoft_Json_JsonPropertyAttribute.htm
