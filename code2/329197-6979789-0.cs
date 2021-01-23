        public static string ConvertToString(object o)
        {
            if (o == null)
                return "null";
            var type = o.GetType();
            if (type == typeof(YourType))
            {
                return ((YourType)o).Property;
            }
            else
            {
                return o.ToString();
            }
        }
