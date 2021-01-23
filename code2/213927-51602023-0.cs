        public Dictionary<string, string> ToDictionary(object obj)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            Type objectType = obj.GetType();
            IList<PropertyInfo> props = new List<PropertyInfo>(objectType.GetProperties());
            foreach (PropertyInfo prop in props)
            {
                object propValue = prop.GetValue(obj, null);
                dictionary.Add(prop.Name, propValue.ToString());
            }
            return dictionary;
