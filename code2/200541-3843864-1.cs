    private void DoProperties(IHasProperties obj)
    {
        foreach (var prop in obj.Properties)
        {
            string name = prop.Name;
            string value = prop.Value;
        }
    }
