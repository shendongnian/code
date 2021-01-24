	public class UpcastingContractResolver<TDerived, TBase> : DefaultContractResolver where TDerived: TBase
	{
		readonly HashSet<string> baseProperties = ((JsonObjectContract)JsonSerializer.Create().ContractResolver.ResolveContract(typeof(TBase)))
			.Properties.Select(p => p.UnderlyingName)
			.ToHashSet();
	
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            var properties = base.CreateProperties(type, memberSerialization);
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
