        public static class ObjectMapper
        {
            #region properties_and_variables
            private static object mutex = new object();
            public static bool UseDeferredExecution { get; set; } = true;
    
            private static Dictionary<string, string> map_dict = new Dictionary<string, string>();
            #endregion
    
    #region public_interface
            public static void SetMapping(string propertyName, string mapTo)
            {
                lock(mutex)
                {
                    map_dict[propertyName] = mapTo;
                }            
            }
            public static IEnumerable<T> Map<T>(this DataTable table) where T : new()
            {
                var result = table.Select().Select(row => ConvertRow<T>(row, table.Columns, typeof(T).GetProperties()));
                return UseDeferredExecution ? result : result.ToArray();
            }
            #endregion
    #region implementation_details
            private static T ConvertRow<T>(DataRow row, DataColumnCollection columns, System.Reflection.PropertyInfo[] p_info) where T : new()
            {
                var instance = new T();
                foreach (var item in p_info)
                {
                    if (columns.Contains(GetMappingName(item))) SetProperty(row, instance, item);             
                }
                return instance;
            }
    
            private static void SetProperty<T>(DataRow row, T instance, System.Reflection.PropertyInfo item) where T : new()
            {
                string mp_name = GetMappingName(item);
                object value = row[mp_name];
                item.SetValue(instance, value);
            }
    
            private static string GetMappingName(System.Reflection.PropertyInfo item)
            {
                return map_dict.ContainsKey(item.Name) ? map_dict[item.Name] : item.Name;
            }
    #endregion
        }
