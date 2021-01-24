    public class SpecialDoubleConverter : JsonConverter<double>
    {
        public override double ReadJson(JsonReader reader, Type objectType, double existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var rawValue = (string)reader.Value;
            // Decide what should be returned if the value can not be read as double
            // e.g. return some magic value like -17, double.NaN, 0, double.Epsilon, etc.
            return double.TryParse(rawValue, out double result)
                ? result
                : -17;
        }
        public override void WriteJson(JsonWriter writer, double value, JsonSerializer serializer)
        {
            // Writing a double into a json string is the same as the default.
            writer.WriteValue(value.ToString());
        }
    }
