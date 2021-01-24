cs
class PageResponse<T>
{
    public int Count { get; set; }
    public IEnumerable<T> Items { get; set; }
}
public static class QueryableExtensions
{
   public static async Task<PageResponse<T>> GetPage<T>(this IQueryable<T> queryable, int skip, int take)
   {
        var count = await queryable.CountAsync().ConfigureAwait(false);
        return new PageResponse<T>
        {
             Count = count,
             Items = await query.Skip(skip).Take(take).ToListAsync().ConfigureAwait(false)
        }
    }
}
