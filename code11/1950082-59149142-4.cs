    public class GenericContractResolver<T> : DefaultContractResolver  
    {
    
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);
            if (property.UnderlyingName == nameof(Response<T>.Item))
            {
    			foreach( var attribute in System.Attribute.GetCustomAttributes(typeof(T)))
    			{
    				if(attribute is JsonObjectAttribute jobject)
    				{
    					property.PropertyName = jobject.Title;
    				}
    			}
            }
            return property;
        }
    }
