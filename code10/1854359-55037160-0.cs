    class Data
        {
            public string DataPoint;
        }
    
        class CustomData
        {
            public Data Dp;
        }
    
        class Utility
        {
            public T JsonDeserialisation<T>(string jsonFile)
            {
                TextReader textReader = new StreamReader(jsonFile);
                JsonTextReader jsonReader = new JsonTextReader(textReader);
                return JsonSerializer.CreateDefault().Deserialize<T>(jsonReader);
            }
        }
