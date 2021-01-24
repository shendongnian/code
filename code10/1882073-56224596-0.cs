    public class OrgNumberSerializer : SerializerBase<OrgNumber>
    {
        public override OrgNumber Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            var serializer = BsonSerializer.LookupSerializer(typeof(string));
            var data = serializer.Deserialize(context, args);
            return new OrgNumber(data.ToString());
        }
        public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, OrgNumber value)
        {
            var serializer = BsonSerializer.LookupSerializer(typeof(string));
            serializer.Serialize(context, value.Value);
        }
    }
