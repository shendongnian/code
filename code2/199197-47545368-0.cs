        public static class EnumConverter
        {
            public static string[] ToStringArray<T>()
            {
                return Enum.GetNames(typeof(T)).Select(x => x.ToString()).ToArray();
            }
            public static Array ToValueArray<T>()
            {
                return Enum.GetValues(typeof(T));
            }
            public static List<T> ToListOfValues<T>()
            {
                return Enum.GetValues(typeof(T)).Cast<T>().ToList();
            }
        }
