    private List<PropertyInfo> GetFilterProps()
    {
        var t = typeof(TEntity);
        var props = t.GetProperties();
        var filterProps = new List<PropertyInfo>();
        foreach (var prop in props)
        {
            var attr = (SearchProperty[])prop.GetCustomAttributes(typeof(SearchProperty), false);
            if (attr.Length > 0)
            {
                filterProps.Add(prop);
            }
         }
         return filterProps;
    }
