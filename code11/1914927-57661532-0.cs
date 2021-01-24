c#
private static List<Type> GetChildTypeOf(Type parent)
{
    var res = new List<Type>();
    var props = parent.GetProperties();
    foreach (var prop in props)
    {
        var propType = prop.PropertyType;
        var elementType = propType.GetElementType();
        res.Add(elementType);
    }
    return res;
}
Then you make your assertion:
c#
var childType = GetChildTypeOf(typeof(ParentClass));
Assert.True(childType.First() == typeof(ChildClass));
Probably it would be even better to have one method to return them all, and one to return a child type element by given property name.
Edit: good answer by @Ed Plunkett, and also tested on .Net Core 2.2
