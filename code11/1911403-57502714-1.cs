		public class EmptyTolerantStringEnumConverter : StringEnumConverter
		{
			public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
			{
				if (reader.TokenType == JsonToken.String && string.IsNullOrWhiteSpace(reader.Value.ToString()))
					// Return a default value.  Note if deserializing a nullable enum the default value is null
					return Activator.CreateInstance(objectType);
				return base.ReadJson(reader, objectType, existingValue, serializer);
			}		
		}
    And apply it as follows:
		[JsonConverter(typeof(EmptyTolerantStringEnumConverter))]
		public Floor Floor { get; set; }
    Or, if you prefer to map `""` to a nullable:
		[JsonConverter(typeof(EmptyTolerantStringEnumConverter))]
		public Floor? Floor { get; set; }
    Demo fiddle here: https://dotnetfiddle.net/DwGKHU
