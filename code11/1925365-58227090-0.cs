    public class QueryStringSerializer
    {
        private static bool IsPrimitive(object obj)
        {
            return obj.GetType().IsPrimitive || obj is string || obj is Guid;
        }
        private static bool IsEnumerable(object obj)
        {
            return obj is IEnumerable && !IsPrimitive(obj);
        }
        private static bool IsComplex(object obj)
        {
            return !(obj is IEnumerable) && !IsPrimitive(obj);
        }
        private static StringBuilder ToQueryStringInternal(object obj, string prop = null)
        {
            StringBuilder queryString = new StringBuilder();
            //skip null values
            if (obj == null)
                return queryString;
            Type type = obj.GetType();
            PropertyInfo[] properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
            if (IsEnumerable(obj))
            {
                int i = 0;
                foreach (object item in obj as IEnumerable)
                {
                    string query = ToQueryStringInternal(item, $"{prop}[{i}]").ToString();
                    queryString.Append(query);
                    i++;
                }
            }
            else if (IsComplex(obj))
            {
                foreach (PropertyInfo property in properties)
                {
                    string propName = property.Name;
                    object value = property.GetValue(obj);
                    string name = prop == null ? propName : $"{prop}.{propName}";
                    string query = ToQueryStringInternal(value, name).ToString();
                    queryString.Append(query);
                }
            }
            else
            {
                string encoded = HttpUtility.UrlEncode(Convert.ToString(obj));
                queryString.Append($"{prop}={encoded}&");
            }
            return queryString;
        }
        public static string ToQueryString(object obj, string propertyName = null)
        {
            StringBuilder queryString = ToQueryStringInternal(obj, propertyName);
            queryString.Length--;
            return queryString.ToString();
        }
    }
