    public static string FormatValue(object value, string format)
        {
            if (value == null) return "";           
            Type type = value.GetType();
            if (type == typeof(bool))
            {
                if (string.IsNullOrEmpty(format))
                {
                    if ((bool)value)
                    {
                        return "Yes";
                    }
                    else
                    {
                        return "No";
                    }
                }
                else
                {                    
                    if ((bool)value)
                    {
                        return ((char)0x221A).ToString(); 
                    }
                    else
                    {
                        return "";
                    }
                }
            }
            
            return value.ToString();
        }
