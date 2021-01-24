 c#
public class OrderedContractResolver : DefaultContractResolver
{
    protected override System.Collections.Generic.IList<JsonProperty> CreateProperties(System.Type type, MemberSerialization memberSerialization)
    {
        return base.CreateProperties(type, memberSerialization).OrderBy(p => p.PropertyName).ToList();
    }
}
And then set the settings and serialize the object, and the JSON fields will be in alphabetical order:
 c#
var settings = new JsonSerializerSettings()
{
    ContractResolver = new OrderedContractResolver()
};
var json = JsonConvert.SerializeObject(obj, Formatting.Indented, settings);
