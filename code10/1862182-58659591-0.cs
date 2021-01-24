    public static class InMemoryQueryProviderExtensions
    {
        static Dictionary<Type, IQueryable> queries = new Dictionary<Type, IQueryable>();
        public static void SetQuery<T>(IQueryable<T> query)
        {
            lock (queries)
                queries[typeof(T)] = query;
        }
        public static IQueryable<T> GetQuery<T>()
        {
            lock (queries)
                return queries.TryGetValue(typeof(T), out var query) ? (IQueryable<T>)query : Enumerable.Empty<T>().AsQueryable();
        }
        private static IQueryable<T> GetQuery<T>(Dictionary<Type, IQueryable> queryDictionary)
        {
            return queryDictionary.TryGetValue(typeof(T), out var query) ? (IQueryable<T>)query : Enumerable.Empty<T>().AsQueryable();
        }
        public static QueryTypeBuilder<T> ToFakeQuery<T>(this QueryTypeBuilder<T> builder)
            where T : class
        {
            return builder.ToQuery(() => GetQuery<T>());
        }
        public static QueryTypeBuilder<T> ToFakeQuery<T>(this QueryTypeBuilder<T> builder, Dictionary<Type, IQueryable> queryDictionary)
            where T : class
        {
            return builder.ToQuery(() => GetQuery<T>(queryDictionary));
        }
    }
