        public Dictionary<string, object> ToDictionary<T>(string key, T value)
        {
            try
            {
                var payload = new Dictionary<string, object>
                {
                    { key, value }
                }; 
            } catch (Exception e)
            {
                return null;
            }
        }
        public T FromDictionary<T>(Dictionary<string, object> payload, string key)
        {
            try
            {
                JObject jObject = (JObject) payload[key];
                T t = jObject.ToObject<T>();
                return (t);
            }
            catch(Exception e) {
                return default(T);
            }
        }
