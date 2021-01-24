	var json = "{ \"Triangles\": [[1337,1400],[1338],[1339]]}";
	var mesh = JsonConvert.DeserializeObject<Mesh>(json);
	
	public class Mesh
	{
		[JsonConverter(typeof(MyConverter))]
		public Triangle[] Triangles { get; set; }
	}	
	public class Triangle
	{
		[JsonProperty]
		public int[] Indices { get; set; }
	}
	
	public class MyConverter : JsonConverter
	{
		public override bool CanConvert(Type objectType)
		{
			return true;
		}
		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			if (reader.TokenType == JsonToken.Null)
			{
				return null;
			}
			var result =
				JArray.Load(reader)
				.Select(x =>
					new Triangle { Indices = x.Select(y => (int)y).ToArray() }
				);
			return result.ToArray();
		}
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			throw new NotImplementedException();
		}
	}
	
