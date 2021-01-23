        public static T GetValueOrMax<T>(T value) where T:IComparable
        {
            if (value != null)
                return value;
            Type type = typeof (T);
            var propInfo = type.GetProperty("MaxValue", BindingFlags.Static | BindingFlags.Public);
            if (propInfo != null)
                return (T)propInfo.GetValue(null, null);
            
            return value;
        }
