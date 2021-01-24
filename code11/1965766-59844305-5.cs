    public void FillFlags( int combinedFlags )
    {
        foreach (PropertyInfo prop in GetType().GetProperties() )
        {
             if (prop.PropertyType != typeof(bool))
                 continue;
             // Only get here if the property is a bool
        }
    }
