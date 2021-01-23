            /// <summary>
            /// Serialize an object
            /// </summary>
            /// <param name="obj"></param>
            /// <returns></returns>
            public static string Serialize<T>(T data)
            {
                string functionReturnValue = string.Empty;
                
                using (var memoryStream = new MemoryStream())
                {
                    var serializer = new DataContractSerializer(typeof(T));
                    serializer.WriteObject(memoryStream, data);
    
                    memoryStream.Seek(0, SeekOrigin.Begin);
    
                    var reader = new StreamReader(memoryStream);
                    functionReturnValue = reader.ReadToEnd();
                }
    
                return functionReturnValue;
            }
    
    
            /// <summary>
            /// Deserialize object
            /// </summary>
            /// <param name="xml"></param>
            /// <returns>Object<T></returns>
            public static T Deserialize<T>(string xml)
            {
                using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(xml)))
                {
                    var serializer = new DataContractSerializer(typeof(T));
                    T theObject = (T)serializer.ReadObject(stream);
                    return theObject;
                }
            }
