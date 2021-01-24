    public static partial class EfCoreExtensions
    {
    	public static decimal? SumOrDefault<T>(this IQueryable<T> source, Expression<Func<T, decimal?>> selector)
    		=> source.GroupBy(e => 0, selector).Select(g => g.Sum()).AsEnumerable().FirstOrDefault();
    }
