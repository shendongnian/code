    public class ArrayToObjectConverter : JsonConverter {
        public override bool CanRead => true;
        public override bool CanWrite => true;
        public override bool CanConvert(Type type) {
            return false;
        }
        public override object ReadJson(JsonReader reader, Type type, object existingInstance, JsonSerializer serializer) {
            var contract = (JsonObjectContract) serializer.ContractResolver.ResolveContract( type );
            var instance = existingInstance ?? contract.DefaultCreator();
            var array = JArray.Load( reader );
            var obj = Convert( array );
            serializer.Populate( obj.CreateReader(), instance );
            return instance;
        }
        public override void WriteJson(JsonWriter writer, object instance, JsonSerializer serializer) {
            var contract = (JsonObjectContract) serializer.ContractResolver.ResolveContract( instance.GetType() );
            var properties = contract.Properties.Where( IsSerializable );
            var values = properties.Select( i => i.ValueProvider.GetValue( instance ) );
            serializer.Serialize( writer, values );
        }
        // Helpers
        private static JObject Convert(JArray array) {
            var obj = new JObject();
            for (var i = 0; i < array.Count; i++) {
                obj.Add( "Item" + i, array[ i ] );
            }
            return obj;
        }
        private static bool IsSerializable(JsonProperty property) {
            return !property.Ignored && property.Readable && property.Writable;
        }
    }
