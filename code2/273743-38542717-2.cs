    public static class EnumHelper
    {
        public static IDictionary<int, string> ConvertToDictionary<T>() where T : struct
        {
            var dictionary = new Dictionary<int, string>();
            var values = Enum.GetValues(typeof(T));
            foreach (var value in values)
            {
                int key = (int) value;
                dictionary.Add(key, value.ToString());
            }
            return dictionary;
        }
    }
