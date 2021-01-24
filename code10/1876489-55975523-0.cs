    public class JsonMockConverter : JsonConverter {
        static readonly Dictionary<object, Func<object>> mockSerializers = new Dictionary<object, Func<object>>();
        static readonly HashSet<Type> mockTypes = new HashSet<Type>();
        public static void RegisterMock<T>(Mock<T> mock, Func<object> serializer) where T : class {
            mockSerializers[mock.Object] = serializer;
            mockTypes.Add(mock.Object.GetType());
        }
        public override bool CanConvert(Type objectType) => mockTypes.Contains(objectType);
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) => 
            throw new NotImplementedException();
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
            if (!mockSerializers.TryGetValue(value, out var mockSerializer)) {
                throw new InvalidOperationException("Attempt to serialize unregistered mock.");
            }
            serializer.Serialize(writer, mockSerializer());
        }
    }
