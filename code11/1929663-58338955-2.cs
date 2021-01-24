    [JsonConverter(typeof(CustomStringToEnumConverter<WeatherEnum>))]
    public enum WeatherEnum
    {
        [EnumMember(Value = "123good")]
        Good,
        [EnumMember(Value = "bad")]
        Bad
    }
    public class CustomStringToEnumConverter<T> : StringEnumConverter
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (string.IsNullOrEmpty(reader.Value?.ToString()))
            {
                return null;
            }
            try
            {
                return EnumExtensions.GetValueFromEnumMember<T>(reader.Value.ToString());
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
    public static class EnumExtensions
    {
        public static T GetValueFromEnumMember<T>(string value)
        {
            var type = typeof(T);
            if (!type.IsEnum) throw new InvalidOperationException();
            foreach (var field in type.GetFields())
            {
                var attribute = Attribute.GetCustomAttribute(field,
                    typeof(EnumMemberAttribute)) as EnumMemberAttribute;
                if (attribute != null)
                {
                    if (attribute.Value == value)
                        return (T)field.GetValue(null);
                }
                else
                {
                    if (field.Name == value)
                        return (T)field.GetValue(null);
                }
            }
            throw new ArgumentException($"unknow value: {value}");
        }
    }
