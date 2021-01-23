    const string delimiter = "_Enabled";
    foreach (string data in aString) {
      int index = data.IndexOf(delimiter);
      if (index >= 0) {
 
        // Get the name and value out of the data string 
        string name = data.Substring(0, index + delimiter.Length);
        bool value = Convert.ToBoolean(data.Substring(index + delimiter.Length + 1));
        // Find the property with the specified name and change the value
        PropertyInfo  property = GetType().GetProperty(name);
        if (property != null) {
          property.SetValue(this, value);
        }
      }
    }
