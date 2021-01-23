    public static int GetMaxLength(this PropertyInfo prop)
    {
        // TODO: null check on prop
        var attributes = prop.GetCustomeAttributes(typeof(MaxLengthAttribute), false);
        if (attributes != null && attributes.Length > 0)
        {
            MaxLengthAttribute mla = (MaxLengthAttribute)attributes[0];
            return mla.MaxLength;
        }
        
        // Either throw or return an indicator that something is wrong
    }
