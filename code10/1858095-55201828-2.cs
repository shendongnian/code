    public class Achievements2 {
    	[JsonConverter(typeof(AchievementsOneTimeConverter))]
    	public List<string> achievementsOneTime;
    }
    
    public class AchievementsOneTimeConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(object[]);
        }
    
            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                List<string> result = new List<string>();
                foreach (JToken token in JArray.Load(reader).Children())
                {
                    if (token.Type == JTokenType.String)
                    {
                        result.Add(token.ToString());
                    }
                }
                
                return result;
             }
    
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
