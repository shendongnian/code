    class Person
    {
    	public string Name { set; get; }
    }
    
    public class PersonJsonConverter : JsonConverter
    {
    	// private readonly Dictionary<string, string> _propertyMappings;
    
    	public PersonJsonConverter()
    	{
    		/*_propertyMappings = new Dictionary<string, string>
    		{
    			{"name", nameof(Person.Name)}
    		};*/
    	}
    
    	public override bool CanConvert(System.Type objectType)
    	{
    		return objectType.GetTypeInfo().IsClass;
    	}
    
    	public override object ReadJson(JsonReader reader, System.Type objectType, object existingValue, JsonSerializer serializer)
    	{
    		object instance = Activator.CreateInstance(objectType);
    		// List<T> implements the non-generic IList interface
    		IList list = (IList)instance;
    		var typeInfo = objectType.GetTypeInfo();
    		var props = typeInfo.DeclaredProperties.ToList();
    		PropertyInfo prop = props.FirstOrDefault(pi => pi.PropertyType == typeof(Person));
    
    		JObject obj = JObject.Load(reader);
    		var namesArray = obj["names"]; // you can use this instead of for loop on obj.Properties.
    		/*foreach (JProperty jsonProperty in obj.Properties())
    		{
    			if (jsonProperty.Name == "names")
    			{
    				var namesArray = JArray.Parse(jsonProperty.Value.ToString());
    				*/
    				if (namesArray.Type == JTokenType.Array && prop != null)
    				{
    					foreach (var ja in namesArray)
    					{
    						object personInstance = Activator.CreateInstance(prop.PropertyType);
    						PropertyInfo personNamePropInfo = prop.PropertyType.GetProperty(nameof(Person.Name));
    						personNamePropInfo.SetValue(personInstance,
    							Convert.ChangeType(ja, personNamePropInfo.PropertyType), null);
    						list.Add(personInstance); // Whatever you need to add
    					}
    				}
    
    		  /*      break;
    			}
    		}*/
    
    		return instance;
    	}
    
    	public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    	{
    		throw new NotImplementedException();
    	}
    }
