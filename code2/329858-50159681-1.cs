    public class ObjectSerializer : MongoDB.Bson.Serialization.Serializers.ObjectSerializer
    {
         public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, object value)
        {
            var bsonWriter = context.Writer;
            if (value != null && value.GetType().IsEnum)
            {
                var conventions = ConventionRegistry.Lookup(value.GetType());
                var enumRepresentationConvention = (EnumRepresentationConvention) conventions.Conventions.FirstOrDefault(convention => convention is EnumRepresentationConvention);
                if (enumRepresentationConvention != null)
                {
                    switch (enumRepresentationConvention.Representation)
                    {
                        case BsonType.String:
                            value = value.ToString();
                            bsonWriter.WriteString(value.ToString());
                            return;
                    }
                }
            }
            base.Serialize(context, args, value);
        }
    }
