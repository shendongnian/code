    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;
    
    		public static T Clone<T>(T o)
    		{
    			byte[] bytes = SerializeBinary(o);
    			return DeserializeBinary<T>(bytes);
    		}
    
    		public static byte[] SerializeBinary(object o)
    		{
    			if (o == null) return null;
    			BinaryFormatter bf = new BinaryFormatter();
    			using (MemoryStream ms = new MemoryStream())
    			{
    				bf.Serialize(ms, o);
    				return ms.GetBuffer();
    			}
    		}
    
    		public static T DeserializeBinary<T>(byte[] bytes)
    		{
    			if (bytes == null) return default(T);
    			BinaryFormatter bf = new BinaryFormatter();
    			using (MemoryStream ms = new MemoryStream(bytes))
    			{
    				return (T) bf.Deserialize(ms);
    			}
    		}
    
    
     
