        public static class EnumConverter
        {
            public static string[] ToNameArray<T>()
            {
                return Enum.GetNames(typeof(T)).ToArray();
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
