    public static class JsonHelper
    {
        public static T[] FromJson<T>(string json)
        {
            string newJson = "{ \"array\": " + json + "}";
            JToken jToken = JToken.Parse(newJson);
            Wrapper<T> wrapper = jToken.ToObject<Wrapper<T>>();
            return wrapper.array;
        }
    
        [System.Serializable]
        private class Wrapper<T>
        {
            public T[] array;
        }
    }
    
