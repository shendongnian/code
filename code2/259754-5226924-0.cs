    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.StartArray)
                {
                    return serializer.Deserialize<List<FacebookMedia>>(reader);
                }
                else
                {
                    FacebookMedia media = serializer.Deserialize<FacebookMedia>(reader);
                    return new List<FacebookMedia>(new[] {media});
                }
            }
