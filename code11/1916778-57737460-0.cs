		static Dictionary<string, string> GetExtracts(string jsonText)
		{
			var valuetoExtractList = new Dictionary<string, string>();
			using (var reader = new JsonTextReader(new StringReader(jsonText)))
			{
				while (reader.Read())
				{
					if (reader.TokenType.ToString().Equals("PropertyName")
					   && reader.ValueType.ToString().Equals("System.String")
					   && reader.Value.ToString().StartsWith("valuetoExtract"))
					{
						var key = reader.Value.ToString();
						reader.Read();
						valuetoExtractList.Add(key, reader.Value.ToString());
					}
				}
			}
			return valuetoExtractList;
		}
Adapted based on https://stackoverflow.com/questions/52503025/filter-json-properties-by-name-using-jsonpath
