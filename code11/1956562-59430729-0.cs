	public class SingleOrArrayConverter<TItem> : SingleOrArrayConverter<List<TItem>, TItem>
	{
		public SingleOrArrayConverter() : this(true) { }
		public SingleOrArrayConverter(bool canWrite) : base(canWrite) { }
	}
	public class SingleOrArrayConverterFactory : JsonConverterFactory
	{
		public bool CanWrite { get; }
		
		public SingleOrArrayConverterFactory() : this(true) { }
		
		public SingleOrArrayConverterFactory(bool canWrite) => CanWrite = canWrite;
		
		public override bool CanConvert(Type typeToConvert)
		{
			var itemType = GetItemType(typeToConvert);
			if (itemType == null)
				return false;
			if (itemType != typeof(string) && typeof(IEnumerable).IsAssignableFrom(itemType))
				return false;
			if (typeToConvert.GetConstructor(Type.EmptyTypes) == null || typeToConvert.IsValueType)
				return false;
			return true;
		}
		
		public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
		{
			var itemType = GetItemType(typeToConvert);
			var converterType = typeof(SingleOrArrayConverter<,>).MakeGenericType(typeToConvert, itemType);
			return (JsonConverter)Activator.CreateInstance(converterType, new object [] { CanWrite });
		}
		
		static Type GetItemType(Type type)
		{
			// Quick reject for performance
			if (type.IsPrimitive || type.IsArray || type == typeof(string))
				return null;
			while (type != null)
			{
				if (type.IsGenericType)
				{
					var genType = type.GetGenericTypeDefinition();
					if (genType == typeof(CollectionSurrogate<,>))
						return null;
					if (genType == typeof(List<>))
						return type.GetGenericArguments()[0];
					// Add here other generic collection types as required, e.g. HashSet<> or ObservableCollection<> or etc.
				}
				type = type.BaseType;
			}
			return null;
		}
	}
	public class SingleOrArrayConverter<TCollection, TItem> : JsonConverter<TCollection> where TCollection : class, ICollection<TItem>, new()
	{
		public SingleOrArrayConverter() : this(true) { }
		public SingleOrArrayConverter(bool canWrite) => CanWrite = canWrite;
		
		public bool CanWrite { get; }
		
		public override TCollection Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			switch (reader.TokenType)
			{
				case JsonTokenType.Null:
					return null;
					
				case JsonTokenType.StartArray:
					// Deserialize to the type CollectionSurrogate<TCollection, TItem> to avoid infinite recursion in Read()
					return JsonSerializer.Deserialize<CollectionSurrogate<TCollection, TItem>>(ref reader, options)?.BaseCollection;
					
				default:
					var item = JsonSerializer.Deserialize<TItem>(ref reader, options);
					return new TCollection { item };
			}
		}
		
		public override void Write(Utf8JsonWriter writer, TCollection value, JsonSerializerOptions options)
		{
			if (CanWrite && value.Count == 1)
			{
				JsonSerializer.Serialize(writer, value.First(), options);
			}
			else
			{
				writer.WriteStartArray();
				foreach (var item in value)
					JsonSerializer.Serialize(writer, item, options);
				writer.WriteEndArray();
			}
		}
	}
    public class CollectionSurrogate<TCollection, TItem> : ICollection<TItem> where TCollection : ICollection<TItem>, new()
    {
        public TCollection BaseCollection { get; }
        public CollectionSurrogate(TCollection baseCollection) 
		{ 
			if (baseCollection == null)
				throw new ArgumentNullException();
			this.BaseCollection = baseCollection; 
		}
        public CollectionSurrogate() : this(new TCollection()) { }
        public void Add(TItem item) => BaseCollection.Add(item);
        public void Clear() => BaseCollection.Clear();
        public bool Contains(TItem item) => BaseCollection.Contains(item);
        public void CopyTo(TItem[] array, int arrayIndex) => BaseCollection.CopyTo(array, arrayIndex);
        public int Count => BaseCollection.Count;
        public bool IsReadOnly => BaseCollection.IsReadOnly;
        public bool Remove(TItem item) => BaseCollection.Remove(item);
        public IEnumerator<TItem> GetEnumerator() => BaseCollection.GetEnumerator();
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
    }
