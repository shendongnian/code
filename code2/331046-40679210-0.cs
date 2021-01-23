    /// <summary>
    /// Returns the DisplayAttribute of a PropertyInfo (field), if it fails returns null
    /// </summary>
    /// <param name="propertyInfo"></param>
    /// <returns></returns>
    private static string TryGetDisplayName(PropertyInfo propertyInfo)
    {
        string result = null;
        try
        {
            var attrs = propertyInfo.GetCustomAttributes(typeof(DisplayAttribute), true);
            if (attrs.Any())
                result = ((DisplayAttribute)attrs[0]).Name;
        }
        catch (Exception)
        {
            //eat the exception
        }
        return result;
    }
