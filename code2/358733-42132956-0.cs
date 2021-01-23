    public static void TrimAllStrings<TSelf>(this TSelf obj)
        {
            if (obj == null)
                return;
            BindingFlags flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy;
            foreach (PropertyInfo p in obj.GetType().GetProperties(flags))
            {
                Type currentNodeType = p.PropertyType;
                if (currentNodeType == typeof(String))
                {
                    string currentValue = (string)p.GetValue(obj, null);
                    if (currentValue != null)
                    {
                        p.SetValue(obj, currentValue.Trim(), null);
                    }
                }
                // see http://stackoverflow.com/questions/4444908/detecting-native-objects-with-reflection
                else if (currentNodeType != typeof(object) && Type.GetTypeCode(currentNodeType) == TypeCode.Object)
                {
                    if (p.GetIndexParameters().Length == 0)
                    {
                        p.GetValue(obj, null).TrimAllStrings();
                    }else
                    {
                        p.GetValue(obj, new Object[] { 0 }).TrimAllStrings();
                    }
                }
            }
        }
