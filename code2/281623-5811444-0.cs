    public static class MyExtensions
    {
        public static IQueryable<int?> FindSeverity(this IQueryable<User> query,
                                           Expression<Func<User, bool>> predicate)
        {
            var last30Days = DateTime.Today.AddDays(-30);
            return from u in query.Where(predicate)
                   from i in u.Issues
                   where i.Date > last30Days
                   select i.Severity;
        }
    }
