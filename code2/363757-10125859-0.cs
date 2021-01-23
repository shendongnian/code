    string name = null;
    // Select the PropertyInfo of the column.
    PropertyInfo propertyInfo = query.First().GetType().GetProperty("first name");
    if (propertyInfo != null)
    {
      try
      {
        // Select the content of the column.
        name = pi.GetValue(query.First(), null).ToString();
      }
      catch (Exception)
      { 
        // Continue with null-string.
      }
}
