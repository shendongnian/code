    foreach (object obj in al)
    {
        foreach(PropertyInfo prop in obj.GetType().GetProperties(
             BindingFlags.Public | BindingFlags.Instance))
        {
            object value = prop.GetValue(obj, null);
            string name = prop.Name;
            // ^^^^ use those
        }
    }
