    private string m_Name;
    public string Name
    {
        get
        {
            var formatAttribute = typeof(Customer).GetCustomAttributes(false)
                                      .OfType<CustomStringFormatAttribute>
                                      .SingleOrDefault();
            if (formatAttribute != null)
                return m_Name.PadLeft(formatAttribute.MaxLength);
            return m_Name;
        }
        set
        {
            m_Name = value;
        }
    }
