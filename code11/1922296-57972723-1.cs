    public static string PrepareJsonString<T>(object objectToBeParsed)
            {
                DataContractJsonSerializer dataContractSerializer = new DataContractJsonSerializer(typeof(T));
                string json = string.Empty;
                using (var ms = new MemoryStream())
                {
                    dataContractSerializer.WriteObject(ms, (T)objectToBeParsed);
                    ms.Position = 0;
                    StreamReader sr = new StreamReader(ms);
                    json = sr.ReadToEnd();
                }
    
                return json;
            }
