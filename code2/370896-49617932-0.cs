    	public class InterfaceConverter : JsonConverter
	    {
		public override bool CanWrite => false;
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
		}
		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			var token = JToken.ReadFrom(reader);
			var typeVariable = this.GetTypeVariable(token);
			if (TypeExtensions.TryParse(typeVariable, out var implimentation))
			{ }
			else if (!typeof(IEnumerable).IsAssignableFrom(objectType))
			{
				implimentation = this.GetImplimentedType(objectType);
			}
			else
			{
				var genericArgumentTypes = objectType.GetGenericArguments();
				var innerType = genericArgumentTypes.FirstOrDefault();
				if (innerType == null)
				{
					implimentation = typeof(IEnumerable);
				}
				else
				{
					Type genericType = null;
					if (token.HasAny())
					{
						var firstItem = token[0];
						var genericTypeVariable = this.GetTypeVariable(firstItem);
						TypeExtensions.TryParse(genericTypeVariable, out genericType);
					}
					genericType = genericType ?? this.GetImplimentedType(innerType);
					implimentation = typeof(IEnumerable<>);
					implimentation = implimentation.MakeGenericType(genericType);
				}
			}
			return JsonConvert.DeserializeObject(token.ToString(), implimentation);
		}
		public override bool CanConvert(Type objectType)
		{
			return !typeof(IEnumerable).IsAssignableFrom(objectType) && objectType.IsInterface || typeof(IEnumerable).IsAssignableFrom(objectType) && objectType.GetGenericArguments().Any(t => t.IsInterface);
		}
		protected Type GetImplimentedType(Type interfaceType)
		{
			if (!interfaceType.IsInterface)
			{
				return interfaceType;
			}
			var implimentationQualifiedName = interfaceType.AssemblyQualifiedName?.Replace(interfaceType.Name, interfaceType.Name.Substring(1));
			return implimentationQualifiedName == null ? interfaceType : Type.GetType(implimentationQualifiedName) ?? interfaceType;
		}
		protected string GetTypeVariable(JToken token)
		{
			if (!token.HasAny())
			{
				return null;
			}
			return token.Type != JTokenType.Object ? null : token.Value<string>("$type");
		}
	}
