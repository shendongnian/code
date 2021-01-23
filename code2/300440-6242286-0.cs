    public abstract class GenericAccess
    {
        public static IList<T> GetObjectListFromArray<T>(T item)
        {
            var r = new List<T>();
            var obj = typeof(T).Assembly.CreateInstance(typeof(T).FullName);
            var p = obj.GetType().GetProperty("Id", System.Reflection.BindingFlags.IgnoreCase | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
            if (p != null)
            {
                p.SetValue(obj, item, null);
                var m = r.GetType().GetMethod("Add");
                m.Invoke(r, new object[] { obj });
            }
            return r;
        }
    }
