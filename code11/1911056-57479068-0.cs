    public class SensorConverter : JsonConverter
    {
        public override bool CanRead => true;
        public override bool CanWrite => false;
        public override bool CanConvert(Type objectType)
        {
            // Don't do IsAssignableFrom tricks here, because you only know how to convert the abstract class Sensor.
            return objectType == typeof(Sensor);
        }
    
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jObject = JObject.Load(reader);
            string sensorType = jObject["Type"].Value<string>();
            switch (sensorType)
            {
                case "TemperatureSensor":
                    return jObject.ToObject<TemperatureSensor>(serializer);
                case "AutomaticGate":
                    return jObject.ToObject<AutomaticGate>(serializer);
                case "AirConditioner":
                    return jObject.ToObject<AirConditioner>(serializer);
                case "LightSensor":
                    return jObject.ToObject<LightSensor>(serializer);
                default:
                    throw new NotSupportedException($"Sensor type '{sensorType}' is not supported.");
            }
        }
    
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) => throw new NotImplementedException();
    }
