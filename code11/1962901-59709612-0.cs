       public static void CopyValues<T>(T obj1, T obj2)
        {
            var type = typeof(T);
            foreach (var prop in type.GetProperties())
            {
                prop.SetValue(obj1, prop.GetValue(obj2));
            }
        }
