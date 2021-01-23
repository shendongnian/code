    namespace MyNameSpace
    {
        using System.Runtime.Serialization.Json;
        using System.IO;
        using System.Text;
    
        public static class JsonExtensions
        {
            public static string JsonSerialize<T>(this T obj) where T : class
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
                using (MemoryStream stream = new MemoryStream())
                {
                    serializer.WriteObject(stream, obj);
                    return Encoding.Default.GetString(stream.ToArray());
                }
            }
    
            public static T JsonDeserialize<T>(this T obj, string json) where T : class
            {
                using (MemoryStream stream = new MemoryStream(Encoding.Unicode.GetBytes(json)))
                {
                    DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
                    return serializer.ReadObject(stream) as T;
                }
            }
        }
    }
    
    
    ...................
    
    
    void somefuntion()
    {
    	MyObject myObject = new MyObject()
    	...Do stuff to myObject .........
    	............
    
    	// Get myObject as a Json String
    	string json = myObject.JsonSerialize();
    }
