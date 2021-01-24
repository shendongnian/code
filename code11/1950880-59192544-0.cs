public class Poco 
{
    public string Hello {get;set;}
}
When I want to upper case all of the property keys send it through the serialization with my Upper case naming strategy:
var responseModel = JsonConvert.DeserializeObject<TResponse>(data);
return JObject.Parse(JsonConvert.SerializeObject(responseModel, 
            new  JsonSerializerSettings
            {
                DefaultValueHandling = DefaultValueHandling.Ignore,
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new UpperCaseNamingStrategy
                    {
                        OverrideSpecifiedNames = true
                    }
                }
            }));
I wish there was a more generic way of doing this, but this seems like a sensible solution
