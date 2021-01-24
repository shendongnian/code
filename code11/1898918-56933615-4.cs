public class OrderedContractResolver : Newtonsoft.Json.Serialization.DefaultContractResolver
{
    protected override System.Collections.Generic.IList<Newtonsoft.Json.Serialization.JsonProperty> CreateProperties(System.Type type, Newtonsoft.Json.MemberSerialization memberSerialization)
    {
        var @base = base.CreateProperties(type, memberSerialization);
        var ordered = @base
            .OrderBy(p => p.Order ?? int.MaxValue)
            .ThenBy(p => p.PropertyName)
            .ToList();
        return ordered;
    }
}
In order to use a custom contract resolver you have to create a custom `Newtonsoft.Json.JsonSerializerSettings` and set its `ContractResolver` to an instance of it:
var jsonSerializerSettings = new Newtonsoft.Json.JsonSerializerSettings
{
    ContractResolver = new OrderedContractResolver(),
};
and then serialize using the above settings object's instance:
using (Newtonsoft.Json.JsonWriter writer = new Newtonsoft.Json.JsonTextWriter(sw))
{
    var serializer = Newtonsoft.Json.JsonSerializer.Create(jsonSerializerSettings);
    serializer.Serialize(writer, jsonObject);
}
where `sw` is a simple string writer:
var sb = new System.Text.StringBuilder();
var sw = new System.IO.StringWriter(sb);
and `jsonObject` is the object you wish to serialize.
