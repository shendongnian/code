    public static object FindObject(object obj, string propName)
    {
        return obj.GetType().GetProperties()
            .Where(pi => pi.Name == propName && pi.CanRead)
            .Select(pi => pi.GetValue(obj, null))
            .FirstOrDefault();
    }
