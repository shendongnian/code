        public static T SingleOrNew<T>(this IEnumerable<T> query, Func<T> createNew) 
        {
            try
            {
                return query.Single();
            }
            catch (InvalidOperationException)
            {
                return createNew();
            }
        }
