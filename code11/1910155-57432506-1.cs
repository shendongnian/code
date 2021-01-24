cs
var json = @"{
    'method': 'Model',
    'payload': {
        'key': 'value'
    }
}";
var modelBase = JsonConvert.DeserializeObject<ModelBase>(json);
var methodMapping = new Dictionary<string, Type>()
{
    {MethodTypes.Model.ToString(), typeof(Model)},
    {MethodTypes.OtherModel.ToString(), typeof(OtherModel)},
};
            
Type methodClass = methodMapping[modelBase.Method];
var result = JsonConvert.DeserializeObject(json, methodClass);
> **Note**: Since we're programmatically determining the correct type, it's hard to [pass to a generic `<T>`][6], so this uses the overload of `DeserializeObject` that takes `type` as a param
And here are the classes that model incoming messages
cs
public enum MethodTypes
{
    Model,
    OtherModel
}
public class ModelBase
{
    public string Method { get; set; }
}
public class Model : ModelBase
{
    public ModelInfo Payload { get; set; }
    public class ModelInfo
    {
        public string Key { get; set; }
    }
}
public class OtherModel : ModelBase
{
    public ModelInfo Payload { get; set; }
    public class ModelInfo
    {
        public string Foo { get; set; }
    }
}
### `Dictionary<string,string>`
If your data is always going to be `"foo":"bar"` or `"key":"value"` .... `string:string`, then Cid's suggesting to use `Dictionary<string,string> Payload` makes a lot of sense.  Then figure out however you want to map from that c# class in a c# constructor that returns whatever type you want.
### Additional Resources:
* [How to handle both a single item and an array for the same property using JSON.net][4]
* [Deserializing polymorphic json classes without type information using json.net][5]
* [JSON.NET - Conditional Type Deserialization][2]
* [Conditionally deserialize JSON string or array property to C# object using JSON.NET?][3]
[1]: https://en.wikipedia.org/wiki/Strategy_pattern
[2]: https://stackoverflow.com/q/7816780/1366033
[3]: https://stackoverflow.com/q/35782400/1366033
[4]: https://stackoverflow.com/q/18994685/1366033
[5]: https://stackoverflow.com/q/19307752/1366033
[6]: https://stackoverflow.com/q/1292480/1366033
