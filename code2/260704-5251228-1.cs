    public void SetStringValue(object o, String propertyName, String newValue)
    {
        try
        {
            o.GetType().GetProperty(propertyName).SetValue(o, newValue, null);
        }
        catch (Exception ex)
        {
            throw new Exception(String.Format("Failure setting property {0}!", propertyName), ex);
        }
    }
