        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (string.IsNullOrEmpty(reader.Value?.ToString()))
            {
                return null;
            }
            try
            {
                return GetValueFromEnumMember<WeatherEnum>(reader.Value.ToString());
            }
            catch (Exception ex)
            {
                return null;
            }
        }
