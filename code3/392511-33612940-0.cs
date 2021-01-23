    using System.IO;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;
    
    namespace Serialization
    {
        public class Serializer
        {
            public static MemoryStream SerializeToStream(object o)
            {
                MemoryStream stream = new MemoryStream();
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, o);
                return stream;
            }
    
            public static object DeserializeFromStream(MemoryStream stream)
            {
                IFormatter formatter = new BinaryFormatter();
                stream.Seek(0, SeekOrigin.Begin);
                object o = formatter.Deserialize(stream);
                return o;
            }
        }
    }
