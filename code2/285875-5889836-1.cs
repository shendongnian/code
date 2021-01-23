    private DataTable ToDataTable<T>(List<T> items)
    {
        var table = new DataTable(typeof (T).Name);
    
        PropertyInfo[] props = typeof (T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
    
        foreach (PropertyInfo prop in props)
        {
            Type t = GetCoreType(prop.PropertyType);
            table.Columns.Add(prop.Name, t);
        }
    
        foreach (T item in items)
        {
            var values = new object[props.Length];
    
            for (int i = 0; i < props.Length; i++)
            {
                values[i] = props[i].GetValue(item, null);
            }
    
            table.Rows.Add(values);
        }
    
        return table;
    }
    public static Type GetCoreType(Type t)
    {
        if (t != null && IsNullable(t))
        {
            if (!t.IsValueType)
            {
                return t;
            }
            else
            {
                return Nullable.GetUnderlyingType(t);
            }
        }
        else
        {
            return t;
        }
    }
    public static bool IsNullable(Type t)
    {
        return !t.IsValueType || (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>));
    }
