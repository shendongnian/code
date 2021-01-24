    public class GenericContractResolver<T> : DefaultContractResolver  
    {
    
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);
            if (property.UnderlyingName == "data")
            {
    			property.PropertyType = typeof(T);
            }
            return property;
        }
    }
