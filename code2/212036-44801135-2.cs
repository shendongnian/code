    [AttributeUsage(AttributeTargets.Property)]
        public class SimppleMapperAttribute: Attribute
        {
            public string HeaderName { get; set; }
        }
      
         public static class SimpleMapper
    {
        #region properties
        public static bool UseDeferredExecution { get; set; } = true;
        #endregion
    #region public_interface  
 
        public static IEnumerable<T> MapWhere<T>(this DataTable table, Func<T, bool> sortExpression) where T:new()
        {
            var result = table.Select().Select(row => ConvertRow<T>(row, table.Columns, typeof(T).GetProperties())).Where((t)=>sortExpression(t));
            return UseDeferredExecution ? result : result.ToArray();
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
            foreach (var info in p_info)
            {
                if (columns.Contains(GetMappingName(info))) SetProperty(row, instance, info);             
            }
            return instance;
        }
        private static void SetProperty<T>(DataRow row, T instance, System.Reflection.PropertyInfo info) where T : new()
        {
            string mp_name = GetMappingName(info);
            object value = row[mp_name];
            info.SetValue(instance, value);
        }
        private static string GetMappingName(System.Reflection.PropertyInfo info)
        {
            SimppleMapperAttribute attribute = info.GetCustomAttributes(typeof(SimppleMapperAttribute),true).Select((o) => o as SimppleMapperAttribute).FirstOrDefault();
            return attribute == null ? info.Name : attribute.HeaderName;
        }
    #endregion
    }
