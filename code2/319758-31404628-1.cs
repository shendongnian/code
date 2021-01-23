    static class NHibernateCaseInsensitiveWhereExtensions
    {
        public static IQueryOver<T, T2> WhereEqualsIgnoreCase<T, T2>(this IQueryOver<T, T2> that, Expression<Func<T, object>> column, string value)
        {
            return
                that.Where(
                    Restrictions.Eq(
                        Projections.SqlFunction(
                            "upper", 
                            NHibernateUtil.String,
                            Projections.Property(column)),
                        value.ToUpper()));
        }
    }
