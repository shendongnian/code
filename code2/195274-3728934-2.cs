    public static bool SetVariableyByName(object obj, string var_name, object value)
            {
                FieldInfo info = obj.GetType().GetField(var_name);
                if (info == null)
                    return false;
                /* ELSE */
                info.SetValue(obj, value);
                return true;          
            }
