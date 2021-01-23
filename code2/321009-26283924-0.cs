        public static object MergeJsonData(object item1, object item2)
        {
            if (item1 == null || item2 == null)
                return item1 ?? item2 ?? new object();
            var result = new Dictionary<string, object>();
            foreach (System.Reflection.PropertyInfo fi in item1.GetType().GetProperties().Where(x => x.CanRead))
            {
                var Value = fi.GetValue(item1, null);
                result[fi.Name] = Value;
            }
            foreach (System.Reflection.PropertyInfo fi in item2.GetType().GetProperties().Where(x => x.CanRead))
            {
                var Value = fi.GetValue(item2, null);
                result[fi.Name] = Value;
            }
            return result;
        }
