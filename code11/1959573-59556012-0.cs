    public class Detail
    {
        [BsonSerializer(typeof(DynamicSerializer))]
        public dynamic Value { get; set; }
    }
    public class DynamicSerializer : SerializerBase<dynamic>
    {
        public override dynamic Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            var myBSONDoc = BsonDocumentSerializer.Instance.Deserialize(context);
            return (dynamic)JObject.Parse(context.ToString());
        }
        public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, dynamic value)
        {
            var bson = MongoDB.Bson.BsonDocument.Parse(value.ToString());
            BsonDocumentSerializer.Instance.Serialize(context, args, bson);
        }
    }
