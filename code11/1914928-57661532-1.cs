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
Edit: Here is how it should look for a specific property name:
c#
private static Type GetSpecificChildTypeOf(Type parent, string propertyName)
{
    var propType = typeof(ParentClass).GetProperty(propertyName).PropertyType;
    var elementType = propType.GetElementType();
    return elementType;
}
And use it like this:  
c#
var childType = GetSpecificChildTypeOf(typeof(ParentClass), "Children");
Assert.True(childType == typeof(ChildClass))
Edit: Thanks for marking the answer!
