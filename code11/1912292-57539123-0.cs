    public class JointsConverter : JsonConverter
    {
        public override bool CanRead => true;
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var joints = value as Joints_;
            var jObject = JObject.FromObject(joints.joints_); // we're converting just joints_ instead of whole object
            
            jObject.WriteTo(writer);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            we're initializing joints_ dictionary from saved values
            var joints = new Joints_
            {
                joints_ = serializer.Deserialize<Dictionary<string, int>>(reader)
            };
            return joints;
        }
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Joints_);
        }
    }
