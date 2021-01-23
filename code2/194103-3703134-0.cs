    public static bool TryGetFirstIndexWithReflection(object o, out object value)
    {
        value = null;
        // find an indexer taking only an integer...
        var property = o.GetType().GetProperty("Item", new Type[] { typeof(int) });
        // if the property exists, retrieve the value...
        if (property != null)
        {
            value = property.GetValue(list, new object[] { 0 });
            return true;
        }
        return false;
    }
