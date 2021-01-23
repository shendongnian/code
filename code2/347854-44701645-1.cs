    public static class RowVersionEfExtensions
    {
        private static readonly MethodInfo BinaryGreaterThanMethodInfo = typeof(RowVersionEfExtensions).GetMethod(nameof(BinaryGreaterThanMethod), BindingFlags.Static | BindingFlags.NonPublic);
        private static bool BinaryGreaterThanMethod(byte[] left, byte[] right)
        {
            throw new NotImplementedException();
        }
        private static readonly MethodInfo BinaryLessThanMethodInfo = typeof(RowVersionEfExtensions).GetMethod(nameof(BinaryLessThanMethod), BindingFlags.Static | BindingFlags.NonPublic);
        private static bool BinaryLessThanMethod(byte[] left, byte[] right)
        {
            throw new NotImplementedException();
        }
        
        /// <summary>
        /// Filter the query to return only rows where the RowVersion is greater than the version specified
        /// </summary>
        /// <param name="query">The query to filter</param>
        /// <param name="propertySelector">Specifies the property of the row that contains the RowVersion</param>
        /// <param name="version">The row version to compare against</param>
        /// <returns>Rows where the RowVersion is greater than the version specified</returns>
        public static IQueryable<T> WhereVersionGreaterThan<T>(this IQueryable<T> query, Expression<Func<T, byte[]>> propertySelector, byte[] version)
        {
            var memberExpression = propertySelector.Body as MemberExpression;
            if (memberExpression == null) { throw new ArgumentException("Expression should be of form r=>r.RowVersion"); }
            var propName = memberExpression.Member.Name;
            var fooParam = Expression.Parameter(typeof(T));
            var recent = query.Where(Expression.Lambda<Func<T, bool>>(
                Expression.GreaterThan(
                    Expression.Property(fooParam, propName),
                    Expression.Constant(version),
                    false,
                    BinaryGreaterThanMethodInfo),
                fooParam));
            return recent;
        }
        
        
        /// <summary>
        /// Filter the query to return only rows where the RowVersion is less than the version specified
        /// </summary>
        /// <param name="query">The query to filter</param>
        /// <param name="propertySelector">Specifies the property of the row that contains the RowVersion</param>
        /// <param name="version">The row version to compare against</param>
        /// <returns>Rows where the RowVersion is less than the version specified</returns>
        public static IQueryable<T> WhereVersionLessThan<T>(this IQueryable<T> query, Expression<Func<T, byte[]>> propertySelector, byte[] version)
        {
            var memberExpression = propertySelector.Body as MemberExpression;
            if (memberExpression == null) { throw new ArgumentException("Expression should be of form r=>r.RowVersion"); }
            var propName = memberExpression.Member.Name;
            var fooParam = Expression.Parameter(typeof(T));
            var recent = query.Where(Expression.Lambda<Func<T, bool>>(
                Expression.LessThan(
                    Expression.Property(fooParam, propName),
                    Expression.Constant(version),
                    false,
                    BinaryLessThanMethodInfo),
                fooParam));
            return recent;
        }
        
    }
