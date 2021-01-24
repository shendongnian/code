	public class Person
	{
		public string name { get; set; }
		[BsonSerializer(typeof(JsonStringAsObjectSerializer<Dob>))]
		public string dob { get; set; }
		class Dob // The DTO
		{
			public string month { get; set; }
			public int day { get; set; }
			public int year { get; set; }
		}
	}
	public class JsonStringAsObjectSerializer<TObject> : SerializerBase<string> where TObject : class
	{
		public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, string value)
		{
            if (value == null)
            {
                var bsonWriter = context.Writer;
                bsonWriter.WriteNull();
            }
            else
            {
				var obj = MyBsonExtensionMethods.FromJson<TObject>(value);
				var serializer = BsonSerializer.LookupSerializer(typeof(TObject));
				serializer.Serialize(context, obj);
            }			
		}
		
        public override string Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            var bsonReader = context.Reader;
			var serializer = BsonSerializer.LookupSerializer(typeof(TObject));
			var obj = (TObject)serializer.Deserialize(context);
			return (obj == null ? null : BsonExtensionMethods.ToJson(obj));
        }
	}
