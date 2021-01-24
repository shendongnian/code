public class Foo
{
  public string Type { get; set; }
  [JsonProperty("parameters")]
  public List<Dictionary<string, object>> Parameters { get; set; }
  [JsonProperty("defaultValue")]
  public string DefaultValue { get; set; }
}
var values = JsonConvert.DeserializeObject<Foo>(jsonStr);
values.Parameters = values
    .Parameters
    .Select(
        dic => dic
            .Where(kvp => new string[] { "A", "B", "C" }.Contains(kvp.Key))
            .ToDictionary(kvp => kvp.Key, kvp => kvp.Value))
    .ToList();
Console.WriteLine(JsonConvert.SerializeObject(values));
  [1]: https://www.newtonsoft.com/json
  [2]: https://dotnetfiddle.net/bXJaSL
