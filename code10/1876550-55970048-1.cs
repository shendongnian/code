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
    .Where(dic =>
        dic.Keys.Intersect(new string[] {"A","B","C"}).Count() == 0)
    .ToList();
Console.WriteLine(JsonConvert.SerializeObject(values));
  [1]: https://www.newtonsoft.com/json
