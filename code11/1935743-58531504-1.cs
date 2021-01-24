	public static partial class JsonExtensions
	{
		public static XDocument DeserializeXNode(string json, DateParseHandling dateParseHandling, 
													 string deserializeRootElementName = null, bool writeArrayAttribute = false, bool encodeSpecialCharacters = false)
		{
			var settings = new JsonSerializerSettings
			{
				Converters = 
				{ 
					new Newtonsoft.Json.Converters.XmlNodeConverter() 
					{
						DeserializeRootElementName = deserializeRootElementName,
						WriteArrayAttribute = writeArrayAttribute,
						EncodeSpecialCharacters = encodeSpecialCharacters
					} 
				},
				DateParseHandling = dateParseHandling,
			};
    		return JsonConvert.DeserializeObject<XDocument>(json, settings);
		}
	}
