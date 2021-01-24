public class Foo
{
  public string Type { get; set; }
  public Dictionary<string, object> Parameters { get; set; }
}
var values = JsonConvert.DeserializeObject<Foo>(jsonStr);
foreach(var key in new string[]{ "A", "B", "C" })
{
    values.Parameters.Remove(key);
}
Console.WriteLine(JsonConvert.SerializeObject(values));
  [1]: https://www.newtonsoft.com/json
