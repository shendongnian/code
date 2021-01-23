    // Modification to original source code.
    Type type = instance.GetType();
    
    if (instance.GetType().Name == "DataTable")
    {
        // Added to handle custom type.
        DataTable dt = (DataTable)instance;
        copy = dt.Copy();
    }
    else if (instance.GetType().Name == "DataSet")
    {
        // Added to handle custom type.
        DataSet ds = (DataSet)instance;
        copy = ds.Copy();
    }
    else
    {
        // This is the original source.
        while (type != null)
        {
            foreach (FieldInfo field in type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
            {
                object value = field.GetValue(instance);
                if (visited.ContainsKey(value))
                    field.SetValue(copy, visited[value]);
                else
                    field.SetValue(copy, value.Clone(visited));
            }
            type = type.BaseType;
        }
    }
    return copy;
