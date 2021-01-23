    public class SafeObjectIdSerializer: ObjectIdSerializer
    {
        public SafeObjectIdSerializer() : base() { }
        public override ObjectId Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            var bsonReader = context.Reader;
            var bsonType = bsonReader.GetCurrentBsonType();
            switch (bsonType)
            {
                case BsonType.Binary: {
                    var value = bsonReader
                            .ReadBinaryData()
                            .AsGuid
                            .ToString()
                            .Replace("-", "")
                            .Substring(0, 24);
                    return new ObjectId(value);
                }
            }
            return base.Deserialize(context, args);
        }
    }
