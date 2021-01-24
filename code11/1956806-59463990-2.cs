	public static partial class MyBsonExtensionMethods
	{
		// Not sure why but BsonExtensionMethods.cs seems to lack methods for deserializing from JSON, so I added some here.
		// See https://github.com/mongodb/mongo-csharp-driver/blob/master/src/MongoDB.Bson/BsonExtensionMethods.cs 
        public static TNominalType FromJson<TNominalType>(
			string json,
            JsonReaderSettings readerSettings = null,
            IBsonSerializer<TNominalType> serializer = null,
            Action<BsonDeserializationContext.Builder> configurator = null)
        {
			return (TNominalType)FromJson(json, typeof(TNominalType), readerSettings, serializer, configurator);
        }
        public static object FromJson(
			string json,
            Type nominalType,
            JsonReaderSettings readerSettings = null,
            IBsonSerializer serializer = null,
            Action<BsonDeserializationContext.Builder> configurator = null)
        {
            if (nominalType == null || json == null)
                throw new ArgumentNullException();
            serializer = serializer ?? BsonSerializer.LookupSerializer(nominalType);
            if (serializer.ValueType != nominalType)
                throw new ArgumentException(string.Format("serializer.ValueType {0} != nominalType {1}.", serializer.GetType().FullName, nominalType.FullName), "serializer");
            using (var textReader = new StringReader(json)) 
			using (var reader = new JsonReader(textReader, readerSettings ?? JsonReaderSettings.Defaults))
			{
				var context = BsonDeserializationContext.CreateRoot(reader, configurator);
				return serializer.Deserialize(context);
			}
        }
    }
