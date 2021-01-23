    var props = new Dictionary<string, object>();
    foreach(var prop in hObj.GetType().GetProperties(BindingFlags.Public|BindingFlags.Instance);)
    {
        props.Add(prop.Name, prop.GetValue(hObj, null));
    }
