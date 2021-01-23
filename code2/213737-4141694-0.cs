    public static void Assign(object value, ref bool variable)
    {
        if (value == null) return;
    
        bool result;
        if (Boolean.TryParse(value.ToString(), out result))
        {
            variable = result;
        }
    }
