	public class DocumentBinder : KnownTypesBinder
	{
		static readonly Dictionary<string, Type> nameToType = new Dictionary<string, Type>
		{
			{"Dog", typeof(Dog)},
			{"Car", typeof(Car)},
		};
		public DocumentBinder() : base(nameToType) { }
	}
	
	public class KnownTypesBinder : ISerializationBinder
	{
		readonly Dictionary<string, Type> nameToType;
		readonly Dictionary<Type, string> typeToName;
		public KnownTypesBinder(IEnumerable<KeyValuePair<string, Type>> nameToType)
		{
			this.nameToType = nameToType.ToDictionary(p => p.Key, p => p.Value);
			this.typeToName = nameToType.ToDictionary(p => p.Value, p => p.Key);
		}
        public Type BindToType(string assemblyName, string typeName)
        {
			if(nameToType.TryGetValue(typeName, out var type))
				return type;
			throw new JsonSerializationBinderException(string.Format("Unknown type name {0} ({1})", typeName, assemblyName));
        }
        public void BindToName(Type serializedType, out string assemblyName, out string typeName)
        {
			if(!typeToName.TryGetValue(serializedType, out typeName))
				throw new JsonSerializationBinderException(string.Format("Unknown type {0}", serializedType));
			assemblyName = null;
        }
	}
    public class JsonSerializationBinderException : JsonSerializationException
    {
        public JsonSerializationBinderException() { }
        public JsonSerializationBinderException(string message) : base(message) { }
        public JsonSerializationBinderException(string message, Exception innerException) : base(message, innerException) { }
        public JsonSerializationBinderException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
