        public static bool IsNullOrEmpty(MyClass prop)
        {
            bool result = true;
            PropertyInfo[] ps = prop.GetType().GetProperties();
            foreach (PropertyInfo pi in ps)
            {
                string value = pi.GetValue(prop, null).ToString();
                if (string.IsNullOrEmpty(value))
                {
                    result = false;
                    break;
                }
            }
            return result;
        }
