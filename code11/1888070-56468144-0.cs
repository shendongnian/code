	public class UpcastingContractResolver<TDerived, TBase> : DefaultContractResolver where TDerived: TBase
	{
		readonly HashSet<string> baseProperties = ((JsonObjectContract)JsonSerializer.Create().ContractResolver.ResolveContract(typeof(TBase)))
			.Properties.Select(p => p.UnderlyingName)
			.ToHashSet();
	
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            var properties = base.CreateProperties(type, memberSerialization);
            // If object type is a subclass of MyDynamicObject and the property is declared
            // in a subclass of MyDynamicObject, assume it is marked with JsonProperty 
            // (unless it is explicitly ignored).  By checking IsSubclassOf we ensure that 
            // "bookkeeping" properties like Count, Keys and Values are not serialized.
			if (type == typeof(TDerived) || type.IsSubclassOf(typeof(TDerived)))
			{
				foreach (var property in properties)
				{
					if (!baseProperties.Contains(property.UnderlyingName))
						property.Ignored = true;
				}
			}
            return properties;
        }
	}
