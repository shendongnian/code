    /// <summary>
    /// Convert any custom object to a dictionary, for use with error logging functionality
    /// </summary>
    /// <param name="customObj">The custom object to convert.</param>
    /// <returns>Returns a dictionary containing all of the custom object's public, readable fields and their values.</returns>
    public static Dictionary<string, object> GenericToDictionaryStrObj(Object customObj)
    {
      var _dictionary = new Dictionary<string, object>();
      try
      {
        var props = customObj.GetType()
          .GetProperties(BindingFlags.Instance | BindingFlags.Public)                         // Do not include private fields
          .Where(p => p.CanRead)
          .Where(p => !String.IsNullOrEmpty(Convert.ToString(p.GetValue(customObj, null))));  // Do not include empty/null values
        foreach (var p in props)
          _dictionary.Add(p.Name, p.GetValue(customObj, null) ?? string.Empty);
      }
      catch
      {
        _dictionary.Add("Error", "Unable to access the properties of the custom object.");
      }
      return _dictionary;
    }
