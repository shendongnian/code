        public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, ObjectId value)
        {
            var bsonWriter = context.Writer;
            var guidString = value
                .ToString()
                .Insert(8, "-")
                .Insert(13, "-")
                .Insert(18, "-")
                .Insert(23, "-") + "00000000";
            var asGuid = new Guid(guidString);
            bsonWriter.WriteBinaryData(new BsonBinaryData(asGuid));
        }
