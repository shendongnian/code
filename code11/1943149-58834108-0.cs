public class Msg
{
    public string interactive_link { get; set; }
}
public class DataObject
{
    public Msg msg { get; set; }
}
And the parse your JSON result to the defined object:
var result = Newtonsoft.Json.JsonConvert.DeserializeObject<DataObject>(data);
