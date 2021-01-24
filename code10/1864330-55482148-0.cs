    public class MyContractResolver : DefaultContractResolver
	{
        protected override JsonContract CreateContract(Type objectType)
        {
			// Prefer JsonDynamicContract for MyDynamicObject
			if (typeof(MyDynamicObject).IsAssignableFrom(objectType))
			{
				return CreateDynamicContract(objectType);
			}
            return base.CreateContract(objectType);
        }
		
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            var properties = base.CreateProperties(type, memberSerialization);
			// If object type is a subclass of MyDynamicObject and the property is declared
			// in a subclass of MyDynamicObject, assume it is marked with JsonProperty 
			// (unless it is explicitly ignored).  By checking IsSubclassOf we ensure that 
			// "bookkeeping" properties like Count, Keys and Values are not serialized.
			if (type.IsSubclassOf(typeof(MyDynamicObject)) && memberSerialization == MemberSerialization.OptOut)
			{
				foreach (var property in properties)
				{
					if (!property.Ignored && property.DeclaringType.IsSubclassOf(typeof(MyDynamicObject)))
					{
						property.HasMemberAttribute = true;
					}
				}
			}
			return properties;
		}
	}
