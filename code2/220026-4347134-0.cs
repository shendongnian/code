    public class MyBusinessObject
    {
        private readonly Dictionary<string, object> extraProperties = new Dictionary<string, object>();
    
        public int Id { get; set; }
        public string Name { get; set; }
    
        public void SetExtraPropertyValue<T>(string key, T value)
        {
            extraProperties.Add(key, value);
        }
        public T GetExtraPropertyValue<T>(string key, T defaultValue)
        {
            if (extraProperties.ContainsKey(key))
            {
                return (T)extraProperties[key];
            }
    
            return defaultValue;
        }
    }
