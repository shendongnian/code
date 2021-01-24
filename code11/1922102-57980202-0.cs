	public static partial class JsonExtensions
	{
		readonly static IContractResolver defaultResolver = new JsonSerializer().ContractResolver;
		
		public static string WriteDefaultValuesForTypeToString(Type type, IContractResolver resolver = null, Formatting formatting = Formatting.None)
		{ 
			using (var sw = new StringWriter())
			{
				using (var jsonWriter = new JsonTextWriter(sw) { Formatting = formatting })
				{
					WriteDefaultValuesForType(type, jsonWriter, resolver);
				}
				return sw.ToString();
			}
		}
		
		public static void WriteDefaultValuesForType(Type type, JsonWriter writer, IContractResolver resolver = null)
		{ 
			var serializer = JsonSerializer.Create(new JsonSerializerSettings{ ContractResolver = resolver });
			WriteDefaultValuesForType(type, writer, serializer, null, 0);
		}
		
		static void WriteDefaultValuesForType(Type type, JsonWriter writer, JsonSerializer serializer, JsonProperty parent, int depth)
		{ 
			var contract = serializer.ContractResolver.ResolveContract(type);
			var defaultValue = parent?.DefaultValue;
			if (defaultValue == null && type.IsValueType && Nullable.GetUnderlyingType(type) == null)
			{
				defaultValue = contract.DefaultCreator();
			}
			if (contract is JsonPrimitiveContract primitive)
			{
				serializer.Serialize(writer, defaultValue);
			}
			else if (contract is JsonObjectContract obj)
			{
				if (depth > 0 && defaultValue == null)
				{
					writer.WriteNull();
				}
				else
				{
					writer.WriteStartObject();
					foreach (var p in obj.Properties)
					{
						writer.WritePropertyName(p.PropertyName);
						WriteDefaultValuesForType(p.PropertyType, writer, serializer, p, depth++);
					}
					writer.WriteEndObject();
				}
			}
			else if (contract is JsonArrayContract array)
			{
				writer.WriteStartArray();
				writer.WriteEndArray();
			}
			else if (contract is JsonDictionaryContract dict)
			{
				if (depth > 0 && defaultValue == null)
				{
					writer.WriteNull();
				}
				else
				{
					writer.WriteStartObject();
					writer.WriteEndObject();
				}
			}
			else if (contract is Newtonsoft.Json.Serialization.JsonLinqContract linq)
			{
				/* What to do here? */
				writer.WriteNull();
			}
			else
			{
				//JsonISerializableContract, JsonDynamicContract, 
				throw new JsonSerializationException(string.Format("Unsupported contract {0}", contract));
			}
		}
	}
