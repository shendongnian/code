    public class PhysicalConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Physical);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            string value = (string)reader.Value;
            string[] parts = value.Split(new char[] { ' ' }, 2);
            Dimension dim;
            if (!DimensionsByUnit.TryGetValue(parts[1], out dim)) dim = Dimension.Force;
            Physical physical = new Physical()
            {
                Dimension = dim,
                Value = double.Parse(parts[0]),
                Unit = parts[1]
            };
            return physical;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            Physical physical = (Physical)value;
            writer.WriteValue(physical.Value.ToString("N0") + " " + physical.Unit);
        }
        private static Dictionary<string, Dimension> DimensionsByUnit = new Dictionary<string, Dimension>
        {
            { "mg", Dimension.Weight },
            { "g", Dimension.Weight },
            { "kg", Dimension.Weight },
            { "°C", Dimension.Temperature },
            { "°F", Dimension.Temperature },
            { "°K", Dimension.Temperature },
            { "µs", Dimension.Time },
            { "ms", Dimension.Time },
            { "s", Dimension.Time },
            { "mm", Dimension.Displacement },
            { "cm", Dimension.Displacement },
            { "m", Dimension.Displacement },
        };
    }
