    public class AgencyTypeConverter : JsonConverter<AgencyTypes> {
        public override AgencyTypes ReadJson(JsonReader reader, Type objectType, AgencyTypes existingValue, bool hasExistingValue, JsonSerializer serializer) {
            var enumString = (string)reader.Value;
            return (AgencyTypes)LookupDescription(enumString, objectType);
        }
        private static object LookupDescription(string description, Type enumType) {
            if (!enumType.IsEnum)
                throw new ArgumentException("Type provided must be an Enum", enumType.Name);
            var field = enumType.GetFields().Where(fieldInfo => {
                var attribute =
                    Attribute.GetCustomAttribute(fieldInfo, typeof(System.ComponentModel.DescriptionAttribute))
                    as System.ComponentModel.DescriptionAttribute;
                return ((attribute != null && attribute.Description == description) || fieldInfo.Name == description);
            }).FirstOrDefault();
            return field?.GetValue(null) ??
            throw new ArgumentException($"Requested value for '{description}' in enum {enumType.Name} was not found", nameof(description));
        }
        public override void WriteJson(JsonWriter writer, AgencyTypes value, JsonSerializer serializer) {
            var type = value.GetType();
            var field = type.GetField(value.ToString());
            System.ComponentModel.DescriptionAttribute attribute =
                Attribute.GetCustomAttribute(field, typeof(System.ComponentModel.DescriptionAttribute))
                as System.ComponentModel.DescriptionAttribute;
            if (attribute != null) {
                writer.WriteValue(attribute.Description);
            } else {
                writer.WriteValue(value);
            }
        }
    }
