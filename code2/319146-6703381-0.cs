It uses the Extensions, and should always return an enum
        public static T ToEnum<T>(this string type, T defaultEnum) 
        {
            T holder;
            try
            {
                holder = (T)Enum.Parse(typeof(T), type);
            }
            catch 
            {
                holder = defaultEnum;
            }
            return holder;
        }
