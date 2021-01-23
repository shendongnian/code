    if (t.IsValueType)
    {
        return typeof(Nullable<>).MakeGenericType(t);
    }
    else
    {
        throw new ArgumentException();
    }
