    public class AssociativeArraysConverter<T> : JsonConverter
        where T : IAssociateFieldNameResolver, new()
    {
        private T m_FieldNameResolver;
        public AssociativeArraysConverter()
        {
            m_FieldNameResolver = new T();
        }
        public override bool CanConvert(Type objectType)
        {
            return typeof(IEnumerable).IsAssignableFrom(objectType) &&
                    !typeof(string).IsAssignableFrom(objectType);
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            IEnumerable collectionObj = value as IEnumerable;
            writer.WriteStartObject();
            foreach (object currObj in collectionObj)
            {
                writer.WritePropertyName(m_FieldNameResolver.ResolveFieldName(currObj));
                serializer.Serialize(writer, currObj);
            }
            writer.WriteEndObject();
        }
    }
