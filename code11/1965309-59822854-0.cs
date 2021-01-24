c#
public class RootObject
{
    public string key1 { get; set; }
    public List<string> fileName { get; set; }
}
and change the `Dictionary<String, List<String>>` to `RootObject`
c#
var values = JsonConvert.DeserializeObject<RootObject>(json);
