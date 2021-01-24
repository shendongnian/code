cs
string JsonData = response.Content.ToString();
var input = JObject.Parse(str);
var results = input["results"].Children();
var status = results.First()["status"];
string groupname = status["groupName"].ToString();
string name = status["name"].ToString();
string description = status["description"].ToString();
Console.WriteLine(groupname);
Console.WriteLine(name);
Console.WriteLine(description);
The result in Console
> REJECTED
> REJECTED_PREFIX_MISSING
> Number prefix missing
But I would rather use concrete class. You need to create multiple classes. [Here][1] is good example. 
cs
public class Envelope
{
	public List<Item> Results { get; set; }
}
public class Item
{
	public Status Status { get; set; }
}
public class Status
{
	public int GroupId { get; set; }
	public string GroupName { get; set; }
	public int Id { get; set; }
	public string Name { get; set; }
	public string Description { get; set; }
}
After that the usage is much simpler.
cs
string JsonData = response.Content.ToString();
MyEnvelope envelope = JsonConvert.DeserializeObject<MyEnvelope>(JsonData);
var status = envelope.results[0].status;
Console.WriteLine(status.GroupName);
Console.WriteLine(status.Name);
Console.WriteLine(status.Description);
[1]: https://stackoverflow.com/questions/16339167/how-do-i-deserialize-a-complex-json-object-in-c-sharp-net
