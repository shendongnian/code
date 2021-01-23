        public interface IDateRange
        {
            DateTime Start { get; set; }
            DateTime End { get; set; }
            bool IsDateOptional { get; }
        }
    
        public static class QueryableDateRangeExtensions
        {
            public static IQueryable<T> StartsFrom<T>(this IQueryable<T> query, DateTime date)
                where T : IDateRange
            {
                return query.Where(obj => obj.Start >= date);
            }
    
            public static IQueryable<T> StartsUntil<T>(this IQueryable<T> query, DateTime date)
                where T : IDateRange
            {
                return query.Where(obj => obj.Start < date);
            }
    
            public static IQueryable<T> EndsUntil<T>(this IQueryable<T> query, DateTime date)
                where T : IDateRange
            {
                return query.Where(obj => obj.End <= date);
            }
        }
