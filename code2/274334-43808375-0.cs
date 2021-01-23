        string sJSON;
        Dictionary<string, string> aa1 = new Dictionary<string, string>();
        aa1.Add("one", "1"); aa1.Add("two", "2"); aa1.Add("three", "3");
        Console.Write("JSON form of Person object: ");
        
        sJSON = WriteFromObject(aa1);
        Console.WriteLine(sJSON);
        Dictionary<string, string> aaret = new Dictionary<string, string>();
        aaret = ReadToObject<Dictionary<string, string>>(sJSON);
        public static string WriteFromObject(object obj)
        {            
            byte[] json;
                //Create a stream to serialize the object to.  
            using (MemoryStream ms = new MemoryStream())
            {                
                // Serializer the object to the stream.  
                DataContractJsonSerializer ser = new DataContractJsonSerializer(obj.GetType());
                ser.WriteObject(ms, obj);
                json = ms.ToArray();
                ms.Close();
            }
            return Encoding.UTF8.GetString(json, 0, json.Length);
            
        }
        // Deserialize a JSON stream to object.  
        public static T ReadToObject<T>(string json) where T : class, new()
        {
            T deserializedObject = new T();
            using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            {
                
                DataContractJsonSerializer ser = new DataContractJsonSerializer(deserializedObject.GetType());
                deserializedObject = ser.ReadObject(ms) as T;
                ms.Close();
            }
            return deserializedObject;
        }
