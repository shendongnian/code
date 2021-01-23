        public Dictionary<string, string> GetParameters(object data)
        {
            if (data == null)
                return null;
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            foreach (PropertyInfo property in data.GetType().GetProperties())
                parameters.Add(property.Name, property.GetValue(data, null).ToString());
            return parameters;
        }
