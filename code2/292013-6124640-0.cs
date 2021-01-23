    public static IDictionary<string, object> ToDictionary(this object data) {
            BindingFlags publicAttributes = BindingFlags.Public | BindingFlags.Instance;
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            foreach (PropertyInfo property in 
                     data.GetType().GetProperties(publicAttributes)) { 
                if (property.CanRead) {
                    dictionary.Add(property.Name, property.GetValue(data, null));
                }
            }
            return dictionary;
    }
