    public MyClass() 
    {
        // Sets default property values for all but dates
        Basefunctions.Clear<InternalExaminer>(this);
        // Sets default values by [DefalutValue()] tag.
        foreach (PropertyDescriptor pd in TypeDescriptor.GetProperties(this))
        {
            pd.ResetValue(this);
        }
        // Sets date properties to current date.
        Basefunctions.SetDates<MyClass>(this);
    }
    public static class Basefunctions
    {
        public static void SetDates<T>(object obj)
        {
            string propName = "";
            try
            {
                obj = (T)obj;
                PropertyInfo[] props = obj.GetType().GetProperties()
                               .Where(p => p.PropertyType == typeof(DateTime)).ToArray();
                if (props != null)
                {
                    DateTime date = DateTime.Now;
                    foreach (PropertyInfo pi in props)
                    {
                        propName = pi.Name;
                        if (Nullable.GetUnderlyingType(pi.PropertyType) == null)
                            pi.SetValue(obj, date);
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Could not set date for {propName}.\n{e.Message}");
            }
        }
        public static void Clear<T>(object obj)
        {
            obj = (T)obj;
            PropertyInfo[] props = obj.GetType().GetProperties();
            string propName = "";
            try
            {
                foreach (PropertyInfo pi in props)
                {
                    propName = pi.Name;
                    Type t = Nullable.GetUnderlyingType(pi.PropertyType) ?? pi.PropertyType;
                    if (Nullable.GetUnderlyingType(pi.PropertyType) != null)
                        pi.SetValue(obj, null);
                    else
                    {
                        var val = GetDefaultVal(t);
                        if (t.IsEnum)
                        {
                            // In case enum does not have a 0
                            if (!Enum.IsDefined(t, val))
                                val = EnumMin(pi.PropertyType);
                        }
                        pi.SetValue(obj, val);
                    }
                }
            }
            catch (Exception e)
            {
                string msg = $"Error for {propName}: {e.Message}";
                throw new Exception(msg);
            }
        }
        private static object GetDefaultVal(Type type)
        {
            DefaultValueAttribute att = (DefaultValueAttribute)type.GetCustomAttribute(typeof(DefaultValueAttribute));
            if (att != null)
                return att.Value;
            else
                return type.IsValueType ? Activator.CreateInstance(type) : null;
        }
        private static object EnumMin(Type t)
        {
            Array x = Enum.GetValues(t);
            var ret = x.GetValue(0);
            return ret;
        }
        private static object EnumMax(Type t)
        {
            Array x = Enum.GetValues(t);
            var ret = x.GetValue(x.Length - 1);
            return ret;
        }
    }
