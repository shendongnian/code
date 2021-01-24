 c#
[JsonObject(MemberSerialization.Fields)]
public class DataModel
{
    public string Name { get; set; }
}
with
 c#
var obj = new DataModel { Name = "abc" };
var json = JsonConvert.SerializeObject(obj);
Console.WriteLine(json);
which results in:
 json
{"<Name>k__BackingField":"abc"}
in which case, either *don't do this* (just remove the `MemberSerialization.Fields`) - this works fine:
 c#
public class DataModel
{
    // optional: [JsonProperty("name")] to change "Name": to "name":
    public string Name { get; set; }
}
which gives:
 json
{"Name":"abc"}
(or "name" with the optional bit)
or if you *must* use fields: give them custom names:
 c#
[JsonObject(MemberSerialization.Fields)]
public class DataModel
{
    [field: JsonProperty("name")]
    public string Name { get; set; }
}
which gives:
 json
{"name":"abc"}
