 C#
[JsonConverter( typeof( QueryStringDictionaryConverter ) )]
class QueryStringDictionary : Dictionary<string,string> { }
class QueryStringDictionaryConverter : JsonConverter<QueryStringDictionary>
{
    ... 
}
class MyClass
{
    public QueryStringDictionary Parameters { get; set; }
}
Alternatively you could use `JsonSerializerOptions`
 C#
class MyOtherClass
{
   public Dictionary<string,string> Parameters { get; set; }
}
MyOtherClass Deserialize( string json )
{
    var options = new JsonSerializerOptions
    {
        Converters = { new QueryStringToDictionaryJsonConverter() }
    };
    return JsonSerializer.Deserialize<MyOtherClass>( json, options );  
} 
A potential problem with this approach is that the converter would be used on all `Dictionary<string,string>` properties, which may not be intended. It would work fine for the simple example in the original question.
