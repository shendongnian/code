public class IgnorePropertyNameContractResolver : DefaultContractResolver
{
    protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
    {
        IList<JsonProperty> list = base.CreateProperties(type, memberSerialization);
        foreach (JsonProperty prop in list)
        {
            prop.PropertyName = prop.UnderlyingName;
        }
        return list;
    }
}
You could use Deserialize using Json Property Name
var jsonResponse = "{'InstrumentType':'abc'}";
var instance = JsonConvert.DeserializeObject<InstrumentInfoV11>(jsonResponse);
And Serialize ignoring the Json Property Name
JsonSerializerSettings settings = new JsonSerializerSettings{ContractResolver = new IgnorePropertyNameContractResolver()};
var serialized = JsonConvert.SerializeObject(instance,settings);
**Output**
{"InstrumentTypeCode":"abc"}
