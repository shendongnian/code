    #region Implemented Interfaces
    #region IValueConverter
    /// <summary>
    ///   convert from enum to string
    /// </summary>
    /// <param name = "value"></param>
    /// <param name = "targetType"></param>
    /// <param name = "parameter"></param>
    /// <param name = "culture"></param>
    /// <returns></returns>
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value == null)
        {
            return null;
        }
        string convert = typeof(GlossaryResources).GetProperty(value.ToString()).GetValue(null, null).ToString();
        return new Item { Name = value.ToString(), Value = convert };
    }
    /// <summary>
    ///   convert from string to enum value
    /// </summary>
    /// <param name = "value"></param>
    /// <param name = "targetType"></param>
    /// <param name = "parameter"></param>
    /// <param name = "culture"></param>
    /// <returns></returns>
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value == null)
        {
            return null;
        }
        T enumvalue;
        Enum.TryParse(value.Cast<Item>().Name, out enumvalue);
        return enumvalue;
    }
    #endregion
    #endregion
