    public static class dynamicHelper
        {
            public static ExpandoObject convertToExpando(object obj)
            {
                //Get Properties Using Reflections
                BindingFlags flags = BindingFlags.Public | BindingFlags.Instance;
                PropertyInfo[] properties = obj.GetType().GetProperties(flags);
    
                //Add Them to a new Expando
                ExpandoObject expando = new ExpandoObject();
                foreach (PropertyInfo property in properties)
                {
                    AddProperty(expando, property.Name, property.GetValue(obj));
                }
    
                return expando;
            }
            public static void AddProperty(ExpandoObject expando, string propertyName, object propertyValue)
            {
                //Take use of the IDictionary implementation
                var expandoDict = expando as IDictionary<string, object>;
                if (expandoDict.ContainsKey(propertyName))
                    expandoDict[propertyName] = propertyValue;
                else
                    expandoDict.Add(propertyName, propertyValue);
            }
        }
