      public static void SaveConfiguration(FeedReadConfiguration configuration)
        {
            var props = DictionaryFromType(configuration); 
            foreach (var prop in props)
            {
                SetAppSettingValue(prop.Key,prop.Value.ToString());
            }
         
        }
        private static Dictionary<string, object> DictionaryFromType(object atype)
        {
            if (atype == null) return new Dictionary<string, object>();
            Type t = atype.GetType();
            PropertyInfo[] props = t.GetProperties();
            Dictionary<string, object> dict = new Dictionary<string, object>(); // reflection
            foreach (PropertyInfo prp in props)
            {
                object value = prp.GetValue(atype, new object[] { });
                dict.Add(prp.Name, value);
            }
            return dict;
        }
