foreach(var r in result)
{
    dynamic x = new ExpandoObject();
    foreach(var p in PropertiesSelectedByUser)
    {
        ((IDictionary<string, object>)x)[q.Name] = q.GetPropertyValue(r);
    }
}
`PropertiesSelectedByUser` is a collection of a type which implements `GetPropertyValue(Data d)`
