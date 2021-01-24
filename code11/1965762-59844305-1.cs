    public void FillFlags( int combinedFlags )
    {
        foreach (PropertyInfo prop in GetType().GetProperties() )
        {
             if (prop.GetCustomAttribute<ReflectThisAttribute> == null)
                 continue;
             // Only get here if the property have the attribute
        }
    }
