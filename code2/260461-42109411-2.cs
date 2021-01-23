    public static class QueryOverExtension
    {
        /// <summary>
        /// This method is used in cases where the root type is required
        /// Example: .WhereEqualInsensitive(t => t.Property, stringValue)
        /// </summary>
        public static IQueryOver<T, TU> WhereEqualInsensitive<T, TU>(this IQueryOver<T, TU> queryOver, Expression<Func<T, object>> path, string value)
        {
            return queryOver.Where(Restrictions.Eq(Projections.SqlFunction("upper", NHibernateUtil.String, Projections.Property(path)), value.ToUpper()));
        }
        /// <summary>
        /// This method is used in cases where the root type is NOT required
        /// Example: .WhereEqualInsensitive(() => addressAlias.DefaultEmail, contactEmailAddress)
        /// </summary>
        public static IQueryOver<T, TU> WhereEqualInsensitive<T,TU>(this IQueryOver<T, TU> queryOver, Expression<Func<object>> path, string value)
        {
            return queryOver.Where(Restrictions.Eq(Projections.SqlFunction("upper", NHibernateUtil.String, Projections.Property(path)), value.ToUpper()));
        }
    }
