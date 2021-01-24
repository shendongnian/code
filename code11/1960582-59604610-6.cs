	public class StackConverterFactory : JsonConverterFactory
	{
		public override bool CanConvert(Type typeToConvert)
		{
			return GetStackItemType(typeToConvert) != null;
		}
		public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
		{
			var itemType = GetStackItemType(typeToConvert);
			var converterType = typeof(StackConverter<,>).MakeGenericType(typeToConvert, itemType);
			return (JsonConverter)Activator.CreateInstance(converterType);
		}
		static Type GetStackItemType(Type type)
		{
			while (type != null)
			{
				if (type.IsGenericType)
				{
					var genType = type.GetGenericTypeDefinition();
					if (genType == typeof(Stack<>))
						return type.GetGenericArguments()[0];
				}
				type = type.BaseType;
			}
			return null;
		}
	}
	public class StackConverter<TItem> : StackConverter<Stack<TItem>, TItem>
	{
	}
	public class StackConverter<TStack, TItem> : JsonConverter<TStack> where TStack : Stack<TItem>, new()
	{
		public override TStack Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			var list = JsonSerializer.Deserialize<List<TItem>>(ref reader, options);
			if (list == null)
				return null;
			var stack = typeToConvert == typeof(Stack<TItem>) ? (TStack)new Stack<TItem>(list.Count) : new TStack();
            for (int i = list.Count - 1; i >= 0; i--)
                stack.Push(list[i]);
            return stack;
		}
		public override void Write(Utf8JsonWriter writer, TStack value, JsonSerializerOptions options)
		{
			writer.WriteStartArray();
			foreach (var item in value)
				JsonSerializer.Serialize(writer, item, options);
			writer.WriteEndArray();
		}
	}
