    public static object Clone(object obj)
        {
            object new_obj = Activator.CreateInstance(obj.GetType());
            foreach (PropertyInfo pi in obj.GetType().GetProperties())
            {
                if (pi.CanRead && pi.CanWrite && pi.PropertyType.IsSerializable)
                {
                    pi.SetValue(new_obj, pi.GetValue(obj, null), null);
                }
            }
            return new_obj;
        }
