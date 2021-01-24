    using Newtonsoft.Json;
    using System.IO;    
    public static class MyExtensions
    {
        /// <summary>
        /// Serialize on object to bute[]
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static byte[] SerializeBinary(this object model)
        {
            MemoryStream stream = new MemoryStream();
            try
            {
                using (StreamWriter writer = new StreamWriter(stream))
                using (JsonTextWriter jsonWriter = new JsonTextWriter(writer))
                {
                    Newtonsoft.Json.JsonSerializer ser = new Newtonsoft.Json.JsonSerializer();
                    ser.Serialize(jsonWriter, model);
                    jsonWriter.Flush();
                }
            }
            finally
            {
                stream.Close();
            }
            return stream.ToArray();
        }
        /// <summary>
        /// Deserialize byte[] to an object of type T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="serializedObj"></param>
        /// <returns></returns>
        public static T DeserializeBinary<T>(this byte[] serializedObj)
        {
            MemoryStream stream = new MemoryStream(serializedObj);
            using (StreamReader reader = new StreamReader(stream))
            using (JsonTextReader jsonReader = new JsonTextReader(reader))
            {
                Newtonsoft.Json.JsonSerializer ser = new Newtonsoft.Json.JsonSerializer();
                return ser.Deserialize<T>(jsonReader);
            }
        }
        /// <summary>
        /// Serialize an object to JSON
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static string SerializeJson(this object model)
        {
            var settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
            var json= JsonConvert.SerializeObject(model, settings);
            return json;
        }
        /// <summary>
        /// Deserialize a string to object of T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public static T DeserializeJson<T>(this string json)
        {
            var settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
            T model = JsonConvert.DeserializeObject<T>(json, settings);
            return model;
        }
        /// <summary>
        /// Deserialize a string to object
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static object DeserializeJson(this string json)
        {
            var settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
            object model = JsonConvert.DeserializeObject(json, settings);
            return model;
        }
    }
