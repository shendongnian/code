    PropertyInfo[] properties = A.GetType().GetProperties();
    foreach (var property in properties)
    {
        if (property.CanWrite)
            property.SetValue(A, property.GetValue(B));
    }
