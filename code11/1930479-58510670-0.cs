	using (MemoryStream memoryStream1 = new MemoryStream())
	{
		using (Utf8JsonWriter utf8JsonWriter1 = new Utf8JsonWriter(memoryStream1))
		{
			using (JsonDocument jsonDocument = JsonDocument.Parse(json))
			{
				utf8JsonWriter1.WriteStartObject();
				foreach (var element in jsonDocument.RootElement.EnumerateObject())
				{
					if (element.Name == "TestData")
					{
						utf8JsonWriter1.WritePropertyName(element.Name);
						
						// Staring new object
						utf8JsonWriter1.WriteStartObject();
						
						// Adding "Name" property 
						utf8JsonWriter1.WritePropertyName("Name");
						utf8JsonWriter1.WriteStringValue("John");
						
						// Copying existing values from "TestData" object
						foreach (var testDataElement in element.Value.EnumerateObject())
						{
							testDataElement.WriteTo(utf8JsonWriter1);
						}
						utf8JsonWriter1.WriteEndObject();
					}
					else
					{
						element.WriteTo(utf8JsonWriter1);
					}
				}
				utf8JsonWriter1.WriteEndObject();
			}
		}
		var resultJson = Encoding.UTF8.GetString(memoryStream1.ToArray());
	}
