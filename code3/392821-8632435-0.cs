    dynamic d = { // your code };
    object o = d;
    string[] propertyNames = o.GetType().GetProperties().Select(p => p.Name).ToArray();
    foreach (var prop in propertyNames)
    {
        object propValue = o.GetType().GetProperty(prop).GetValue(o, null);
    }
