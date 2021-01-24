    public class ClassBConverter : JsonConverter<ClassB> {
        ...
        
        public override void WriteJson(JsonWriter writer, ClassB value, JsonSerializer serializer)
        {
            writer.WriteValue((int)value.SomeEnum);
        }
    
        public override ClassB ReadJson(JsonReader reader, Type objectType, ClassB existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            int i = (int)reader.Value;
            return new ClassB { SomeEnum = i };
        }
    }
