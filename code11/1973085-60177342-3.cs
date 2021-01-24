	public class CiphertextConverter : JsonConverter<Ciphertext>
	{
		readonly SEALContext context;
		
		public CiphertextConverter(SEALContext context) => this.context = context ?? throw new ArgumentNullException(nameof(context));
	
        public override Ciphertext ReadJson(JsonReader reader, Type objectType, Ciphertext existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
			var data = serializer.Deserialize<byte []>(reader);
			if (data == null)
				return null;
			var cipherText = new Ciphertext();
			using (var stream = new MemoryStream(data))
				cipherText.Load(context, stream);
			return cipherText;
        }
        public override void WriteJson(JsonWriter writer, Ciphertext value, JsonSerializer serializer)
        {
			using (var stream = new MemoryStream())
			{
				value.Save(stream, ComprModeType.Deflate); // TODO: test to see whether Deflate gives better size vs speed performance in practice.
				writer.WriteValue(stream.ToArray());
			}
        }
	}
