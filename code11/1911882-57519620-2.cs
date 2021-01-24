c#
public class CaseInsensitiveComparer : IComparer<string> 
{ 
    public int Compare(string a, string b) 
    { 
        return string.Compare(a, b, StringComparison.OrdinalIgnoreCase); 
    } 
}
[EnableQuery(HandleNullPropagation = HandleNullPropagationOption.False)]
[ODataRoute]
[AuthorizeScopes(AppScopes.FarmerListRead)]
[HttpGet]
public IQueryable<FarmerViewDto> GetAll()
{
    return _unitOfWork
        .FarmerViewRepository
        .GetAllQueryable()
        .UseAsDataSource()
        .For<FarmerViewDto>();
        .OrderBy(x => x.firstName, new CaseInsensitiveComparer());
}
== Edit ==
The following Queryable extension supports sorting by a single column name in ascending or descending order (defaults to ascending)...
c#
namespace System.Linq
{
    public static class QueryableExtensions
    {
        public static IOrderedQueryable<TSource> Sort<TSource>(this IQueryable<TSource> source, IComparer<string> comparer, string sortExpression)
        {
            bool sortDescending = false;
            if (sortExpression.EndsWith(" DESC", StringComparison.OrdinalIgnoreCase))
            {
                sortDescending = true;
                sortExpression = sortExpression.Substring(0, sortExpression.Length - 5);
            }
            if (sortExpression.EndsWith(" ASC", StringComparison.OrdinalIgnoreCase))
            {
                sortDescending = false;
                sortExpression = sortExpression.Substring(0, sortExpression.Length - 4);
            }
            var param = Expression.Parameter(typeof(TSource), "source");
            var expression = Expression.Lambda<Func<TSource, string>>(Expression.Convert(Expression.Property(param, sortExpression), typeof(string)), param);
            if (!sortDescending)
                return source.OrderBy<TSource, string>(expression, comparer);
            else
                return source.OrderByDescending<TSource, string>(expression, comparer);
        }
    }
}
Which you could then use in the following way...
c#
    return _unitOfWork
        .FarmerViewRepository
        .GetAllQueryable()
        .UseAsDataSource()
        .For<FarmerViewDto>();
        .Sort(new CaseInsensitiveComparer(), "firstName asc");
It assumes all object properties can be sensibly converted to string. If you have custom classes on your properties you'll need to ensure you override `ToString()` appropriately.
Also it only works for a single field, i.e.: `"field"`, `"field1 asc"` or `"field1 desc"`. I'll leave the extra silliness to you if you want something like `"field1 asc, field2 desc"`.
