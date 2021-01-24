    public void Initialize(MyObject valueToSet)
    {
        foreach (FieldInfo field in this.GetType()
                                        .GetFields(BindingFlags.Public | BindingFlags.Instance)
                                        .Where(x => x.Name.Contains("Object")))
        {
            field.SetValue(this, valueToSet);
        }
    }
