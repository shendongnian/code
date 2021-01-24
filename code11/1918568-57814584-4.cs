	public class DifficultyConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
			var token = JToken.Load(reader);
			
			switch (token.Type)
			{
				case JTokenType.Null:
					return null;
					
				case JTokenType.Integer:
					{
						var intv = (int)token;
						return Library.EnumerateDifficulties().FirstOrDefault(d => d.CombatModifier == intv);
					}
				
				case JTokenType.Object:
					return token.DefaultToObject(objectType, serializer);
				
				default:
					throw new JsonSerializationException(string.Format("Unknown token {0}", token.Type));
			}
        }                
        public override bool CanWrite => false;
        public override bool CanConvert(Type objectType) => objectType == typeof(Difficulty);
    }
