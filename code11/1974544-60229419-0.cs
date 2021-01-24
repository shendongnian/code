class SingleOrArrayConverter<T> : JsonConverter
{
public override bool CanConvert(Type objectType)
{
return (objectType == typeof(List<T>));
}
 
public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
{
JToken token = JToken.Load(reader);
if (token.Type == JTokenType.Array)
{
return token.ToObject<List<T>>();
}
return new List<T> { token.ToObject<T>() };
}
 
public override bool CanWrite
{
get { return false; }
}
 
public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
{
throw new NotImplementedException();
}
}
Now, you could deserialize your Json as
string test_string = @"{'EventSpecificInformation':
                                   {
                                   'measure':'' 
                                   ,'Long name':'test_name' 
                                   ,'Short name':'test_s_name' 
                                   ,'Description':''
                                   ,'Status':'Real (Imported)'
                                   ,'Viewers':['Everyone']
                                   ,'Modifiers':['Supervisor only']
                                   ,'calculation':''
                                   }
                               }";
var deserialized_entry = JsonConvert.DeserializeObject<Dictionary<string,Dictionary<string, List<string>>>>(test_string,new SingleOrArrayConverter<string>());
Output 
[![enter image description here][1]][1]
  [1]: https://i.stack.imgur.com/mcZST.png
