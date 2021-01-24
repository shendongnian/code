csharp
public class Data
{
    public double X { get; set; }
    public double Y { get; set; }
    public string Code { get; set; }
}
Then use the generic version of `DeserializeObject` to type your deserialization, such as 
csharp
var array = JsonConvert.DeserializeObject<List<Data>>(postals);
