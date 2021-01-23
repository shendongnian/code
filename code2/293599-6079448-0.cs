    public void VerifyPropertyName(string propertyName)
    {
        if (GetType().GetProperty(propertyName) == null)
            throw new ArgumentException("Property not found", propertyName);
    }
