    public static T Deserialize<T>(string json)
            {
                var obj = Activator.CreateInstance<T>();
                using(var ms = new MemoryStream(Encoding.Unicode.GetBytes(json)))
                {
                    var serializer = new DataContractJsonSerializer(obj.GetType());
                    obj = (T) serializer.ReadObject(ms);
                    return obj;
                }
            }
