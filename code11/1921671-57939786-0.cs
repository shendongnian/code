	public class JsonExtensions
	{
		public static T LoadFromFileOrCreateDefault<T>(string path, JsonSerializerSettings settings = null) where T : new()
		{
			var serializer = JsonSerializer.CreateDefault(settings);
			
			try
			{
				using (var file = File.OpenText(path))
				{
					return (T)JsonSerializer.CreateDefault(settings).Deserialize(file, typeof(T));
				}
			}
			catch (FileNotFoundException)
			{
				return new T();
			}
		}
		
		public static void SaveToFile<T>(T root, string path, Formatting formatting = Formatting.None, JsonSerializerSettings settings = null)
		{
			using (var file = File.CreateText(path))
			using (var writer = new JsonTextWriter(file) { Formatting = formatting })
			{
				JsonSerializer.CreateDefault(settings).Serialize(writer, root);
			}			
		}
	}
