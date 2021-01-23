    public static b
    ool SetVariableyByName(object obj, string var_name, object value)
                {
                    FieldInfo info = obj.GetType().GetField(var_name, BindingFlags.NonPublic| BindingFlags.Instance);
                    if (info == null)
                    return false;
                /* ELSE */
                info.SetValue(obj, value);
                return true;          
            }
