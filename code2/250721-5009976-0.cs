        public static IEnumerable<T> GetEnumValues<T>()
        {
            return typeof(T)
                .GetFields()
                .Where(x => x.IsLiteral)
                .Select(field => (T)field.GetValue(null));
        }
