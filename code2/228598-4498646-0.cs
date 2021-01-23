    void Update(Type type)
    {
        PropertyInfo info = type.GetProperty("Name");
        string name = info.GetValue(info, null);
    }
