        /// <summary>
        /// This call forces immediate evaluation of the expression tree. 
        /// Any earlier expressions are evaluated immediately against the underlying IQueryable (perhaps
        /// a Linq to SQL provider) while any later expressions are evaluated against the resulting object
        /// graph in memory.
        /// This is one way to determine whether expressions get evaluated by the underlying provider or
        /// by Linq to Objects in memory.
        /// </summary>
        public static IEnumerable<T> Evaluate<T>(this IEnumerable<T> expression)
        {
            foreach (var item in expression)
            {
                yield return item;
            }
        }
        /// <summary>
        /// This call forces immediate evaluation of the expression tree. 
        /// Any earlier expressions are evaluated immediately against the underlying IQueryable (perhaps
        /// a Linq to SQL provider) while any later expressions are evaluated against the resulting object
        /// graph in memory.
        /// This is one way to determine whether expressions get evaluated by the underlying provider or
        /// by Linq to Objects in memory.
        /// </summary>
        public static IEnumerable Evaluate(this IEnumerable expression)
        {
            foreach (var item in expression)
            {
                yield return item;
            }
        }
