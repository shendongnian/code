    private readonly List<PropertyInfo> _props;
    protected Foo()
    {
        _props = new List<PropertyInfo>();
        var props = new Dictionary<int, PropertyInfo>();
        foreach (PropertyInfo p in GetType().GetProperties())
        {
            if (Attribute.IsDefined(p, typeof(WriteableAttribute)))
            {
                var attr = (WriteableAttribute)p
                    .GetCustomAttributes(typeof(WriteableAttribute))[0];
                props.Add(attr.Order, p);
            }
        }
        _props.AddRange(props.OrderBy(kvp => kvp.Key).Select(kvp => kvp.Value));
    }
