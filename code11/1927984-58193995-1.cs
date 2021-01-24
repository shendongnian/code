foreach(var r in result)
{
    dynamic x = new ExpandoObject();
    foreach(var p in PropertiesSelectedByUser)
    {
        ((IDictionary<string, object>)x)[p.Name] = p.GetPropertyValue(r);
    }
}
`PropertiesSelectedByUser` is a collection of a type which implements `GetPropertyValue(Data d)`
