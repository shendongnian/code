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
