    public static partial class BsonExtensions
	{
		public static void CopyJsonToBson(string inputPath, string outputPath, FileMode fileMode)
		{
			using ( var textReader = File.OpenText(inputPath) )
			using ( var jsonReader = new JsonTextReader( textReader ))
			using ( var oFileStream = new FileStream( outputPath, fileMode ) )
			{
                CopyJsonToBson(jsonReader, oFileStream);
			}
		}
        public static void CopyJsonToBson(JsonReader jsonReader, Stream stream)
		{
			var rootTokenType = jsonReader.ReadToContentAndAssert().TokenType;
			if (!stream.CanSeek || rootTokenType != JsonToken.StartArray)
			{
				using ( var dataWriter = new BsonDataWriter(stream) { CloseOutput = false } )
				{
					dataWriter.WriteToken(jsonReader, stream.CanSeek);
				}
			}
			else
			{
				stream.Flush(); // Just in case.
				var initialPosition = stream.Position;
				var buffer = new byte[256];
				WriteInt(stream, 0, buffer); // CALCULATED SIZE TO BE CALCULATED LATER.
				ulong index = 0;
				while (jsonReader.ReadToContentAndAssert().TokenType != JsonToken.EndArray)
				{
					var bsonType = GetBsonType(jsonReader.TokenType, jsonReader.ValueType);
					stream.WriteByte(unchecked((byte)bsonType));
					WriteString(stream, index.ToString(NumberFormatInfo.InvariantInfo), buffer);
					using (var dataWriter = new BsonDataWriter(stream) { CloseOutput = false })
					{
						dataWriter.WriteToken(jsonReader);
					}
					index++;
				}
				
				stream.WriteByte((byte)0);
				stream.Flush();
				var finalPosition = stream.Position;
				stream.Position = initialPosition;
				var size = checked((int)(finalPosition - initialPosition));
				WriteInt(stream, size, buffer); // CALCULATED SIZE TO BE CALCULATED LATER.
				
				stream.Position = finalPosition;
			}
		}
		private static readonly Encoding Encoding = new UTF8Encoding(false);
		private static void WriteString(Stream stream, string s, byte[] buffer)
		{
			if (s != null)
			{
				if (s.Length < buffer.Length / Encoding.GetMaxByteCount(1))
				{
					var byteCount = Encoding.GetBytes(s, 0, s.Length, buffer, 0);
					stream.Write(buffer, 0, byteCount);
				}
				else
				{
					byte[] bytes = Encoding.GetBytes(s);
					stream.Write(bytes, 0, bytes.Length);
				}
			}
			stream.WriteByte((byte)0);
		}		
        private static void WriteInt(Stream stream, int value, byte[] buffer)
        {
			unchecked
			{
				buffer[0] = (byte) value;
				buffer[1] = (byte) (value >> 8);
				buffer[2] = (byte) (value >> 16);
				buffer[3] = (byte) (value >> 24);
			}
            stream.Write(buffer, 0, 4);
        }
									 
		private static BsonType GetBsonType(JsonToken jsonType, Type valueType)
		{
			switch (jsonType)
			{
				case JsonToken.StartArray:
					return BsonType.Array;
					
				case JsonToken.StartObject:
					return BsonType.Object;
					
				case JsonToken.Null:
					return BsonType.Null;
					
				// Add primitives as required.
					
				default:
					throw new JsonWriterException(string.Format("BsonType for {0} not implemented.", jsonType));
			}
		}
		
		//Copied from: https://github.com/JamesNK/Newtonsoft.Json.Bson/blob/master/Src/Newtonsoft.Json.Bson/BsonType.cs
		//Original source: http://bsonspec.org/spec.html
		enum BsonType : sbyte
		{
			Number = 1,
			String = 2,
			Object = 3,
			Array = 4,
			Binary = 5,
			Undefined = 6,
			Oid = 7,
			Boolean = 8,
			Date = 9,
			Null = 10,
			Regex = 11,
			Reference = 12,
			Code = 13,
			Symbol = 14,
			CodeWScope = 15,
			Integer = 16,
			TimeStamp = 17,
			Long = 18,
			MinKey = -1,
			MaxKey = 127
		}		
	}
    public static partial class JsonExtensions
    {
        public static JsonReader ReadToContentAndAssert(this JsonReader reader)
        {
            return reader.ReadAndAssert().MoveToContentAndAssert();
        }
        public static JsonReader MoveToContentAndAssert(this JsonReader reader)
        {
            if (reader == null)
                throw new ArgumentNullException();
            if (reader.TokenType == JsonToken.None)       // Skip past beginning of stream.
                reader.ReadAndAssert();
            while (reader.TokenType == JsonToken.Comment) // Skip past comments.
                reader.ReadAndAssert();
            return reader;
        }
        public static JsonReader ReadAndAssert(this JsonReader reader)
        {
            if (reader == null)
                throw new ArgumentNullException();
            if (!reader.Read())
                throw new JsonReaderException("Unexpected end of JSON stream.");
            return reader;
        }
    }
