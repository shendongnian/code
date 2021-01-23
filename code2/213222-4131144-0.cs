        public static IEnumerable<T> ToMyEnumerable<T>(this T input)
        {
            var enumerbale = new[] { input };
            return enumerbale;
        }
    
        source.First( p => p.ID = value).ToMyEnumerable<T>()
