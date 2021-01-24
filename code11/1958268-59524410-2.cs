	internal class Translation : Dictionary<string, string>
	{
		public string Name { get; set; }
	}
	internal class TranslationConverter : JsonConverter<Translation>
	{
		internal class TranslationDTO
		{
			public string Name { get; set; }
			[JsonExtensionData]
			public Dictionary<string, object> Data { get; set; }
		}
		public override Translation Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			var dto = JsonSerializer.Deserialize<TranslationDTO>(ref reader, options);
			if (dto == null)
				return null;
			var translation = new Translation { Name = dto.Name };
			foreach (var p in dto.Data)
				translation.Add(p.Key, p.Value?.ToString());
			return translation;
		}
		public override void Write(Utf8JsonWriter writer, Translation value, JsonSerializerOptions options)
		{
			var dto = new TranslationDTO { Name = value.Name, Data = value.ToDictionary(p => p.Key, p => (object)p.Value) };
			JsonSerializer.Serialize(writer, dto, options);
		}
	}
