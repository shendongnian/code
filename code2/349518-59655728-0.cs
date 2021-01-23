    public static class MyExpando
    {
        public static void Set(this ExpandoObject obj, string propertyName, object value)
        {
            IDictionary<string, object> dic = obj;
            dic[propertyName] = value;
        }
        public static ExpandoObject ToExpando(this object initialObj)
        {
            ExpandoObject obj = new ExpandoObject();
            IDictionary<string, object> dic = obj;
            Type tipo = initialObj.GetType();
            foreach(var prop in tipo.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
            {
                dic.Add(prop.Name, prop.GetValue(initialObj));
            }
            return obj;
        }
    }
