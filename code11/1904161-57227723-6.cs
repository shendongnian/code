	public static class JsonExtensions
	{
		public static T LoadFromFileWithGeoJson<T>(string path, JsonSerializerSettings settings = null)
		{
			var serializer = NetTopologySuite.IO.GeoJsonSerializer.CreateDefault(settings);
			serializer.CheckAdditionalContent = true;
			using (var textReader = new StreamReader(path))
			using (var jsonReader = new JsonTextReader(textReader))
			{
				return serializer.Deserialize<T>(jsonReader);
			}
		}
		
		public static string SerializeWithGeoJson<T>(T obj, Formatting formatting = Formatting.Indented, JsonSerializerSettings settings = null)
		{
			var serializer = NetTopologySuite.IO.GeoJsonSerializer.CreateDefault(settings);
			var sb = new StringBuilder();
			using (var writer = new StringWriter(sb))
			{
				serializer.Formatting = formatting;
				serializer.Serialize(writer, obj);
			}
			return sb.ToString();
		}
	}
