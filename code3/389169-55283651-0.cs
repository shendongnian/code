        /// <summary>
        /// Extract the Internal Object Query from an IQueryable, you might do this to access the internal parameters for logging or injection purposes
        /// </summary>
        /// <remarks>Sourced from https://www.stevefenton.co.uk/2015/07/getting-the-sql-query-from-an-entity-framework-iqueryable/ </remarks>
        /// <typeparam name="T">Entity Type that is the target of the query</typeparam>
        /// <param name="query">The query to inspect</param>
        /// <returns>Object Query that represents the same IQueryable Expression</returns>
        public static System.Data.Entity.Core.Objects.ObjectQuery<T> ToObjectQuery<T>(this IQueryable<T> query)
        {
            // force the query to be cached, otherwise parameters collection will be empty!
            string queryText = query.ToString();
            queryText = queryText.ToLower(); // stop compiler from optimising this code away because we don't do anything with queryText parameter!
            var internalQueryField = query.GetType().GetProperties(System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).Where(f => f.Name.Equals("InternalQuery")).FirstOrDefault();
            var internalQuery = internalQueryField.GetValue(query);
            var objectQueryField = internalQuery.GetType().GetFields(System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).Where(f => f.Name.Equals("_objectQuery")).FirstOrDefault();
            return objectQueryField.GetValue(internalQuery) as System.Data.Entity.Core.Objects.ObjectQuery<T>;
        }
