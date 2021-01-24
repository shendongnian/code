csharp
public class MyObject
{
    public string MyProperty;
}
You could write an extension like this:
csharp
public static class MyQueryExtension
{
    public static IQueryable<MyObject> WhereMyPropertyNull(this IQueryable<MyObject> queryable)
    {
        return queryable.Where(obj => obj.MyProperty == null);
    }
}
And use it like this:
csharp
var queryable = new List<MyObject>().AsQueryable();
var result = queryable.WhereMyPropertyNull().ToList();
**EDIT**
Based on some feedback i updated my answer to handle generics.  
csharp
public static class Extensions
    {
        public static IQueryable<TEntity> EqualOrNull<TEntity, TProperty>(this IQueryable<TEntity> source, Func<TEntity, TProperty> selector, TProperty match)
        {
            return source.Where(entity => Match(selector.Invoke(entity), match));
        }
        private static bool Match<TEntity, TProperty>(TEntity entity, TProperty match)
        {
            if (entity == null) {
                return true;
            } else {
                return entity.Equals(match);
            }
        }
    }
It can be used to pass the value of a property to the where statement:
csharp
            var list = new List<MyObject>();
            list.Add(new MyObject {MyProperty = "Test"});
            list.Add(new MyObject {MyProperty = "NoMatch"});
            list.Add(new MyObject {MyProperty = null});
            
            var result = list.AsQueryable()
                .EqualOrNull(o => o.MyProperty, "Test")
                .ToList();
