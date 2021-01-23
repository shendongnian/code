    public class CustomSerializationProvider : IBsonSerializationProvider
    {
        public IBsonSerializer GetSerializer(Type type)
        {
            if (type == typeof(ObjectId))
            {
                return new SafeObjectIdSerializer();
            }
            //add other custom serializer mappings here
            
            //to fall back on the default:
            return null;
        }
    }
