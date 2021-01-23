    public void CopyPropertiesFrom(SomeClass SourceInstance)
    {
        foreach (PropertyInfo prop in typeof(SomeClass).GetProperties())
            prop.SetValue(this, prop.GetValue(SourceInstance, null), null);
    }
