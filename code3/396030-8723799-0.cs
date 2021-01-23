        public static T Parse<T>(this string source)
        {            
            if (typeof(T).IsSubclassOf(typeof(Enum)))
            {
                return (T)Enum.Parse(typeof(T), source, true);
            }
            if (!String.IsNullOrEmpty(source))
                return (T)Convert.ChangeType(source, typeof(T));
            return default(T);
        }
