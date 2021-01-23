        public static T SingleOrNew<T>(this IEnumerable<T> query, Func<T,bool> predicate, Func<T> createNew) 
        {
            try
            {
                return query.Single(predicate);
            }
            catch (InvalidOperationException)
            {
                return createNew();
            }
        }
