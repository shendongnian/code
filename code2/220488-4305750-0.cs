    private void SetDefaults(object LinqObj)
    {
        // get the properties of the LINQ Object
        PropertyInfo[] props = LinqObj.GetType().GetProperties();
        // iterate through each property of the class
        foreach (PropertyInfo prop in props)
        {
            // attempt to discover any metadata relating to underlying data columns
            try
            {
                // get any column attributes created by the Linq designer
                object[] customAttributes = prop.GetCustomAttributes
                (typeof(System.Data.Linq.Mapping.ColumnAttribute), false);
                // if the property has an attribute letting us know that 
                // the underlying column data cannot be null
                if (((System.Data.Linq.Mapping.ColumnAttribute)
                (customAttributes[0])).DbType.ToLower().IndexOf("not null") != -1)
                {
                    // if the current property is null or Linq has set a date time 
                // to its default '01/01/0001 00:00:00'
                    if (prop.GetValue(LinqObj, null) == null || prop.GetValue(LinqObj, 
                    null).ToString() == (new DateTime(1, 1, 1, 0, 0, 0)).ToString())
                    {
                        // set the default values here : could re-query the database, 
                        // but would be expensive so just use defaults coded here
                        switch (prop.PropertyType.ToString())
                        {
                            // System.String / NVarchar
                            case "System.String":
                                prop.SetValue(LinqObj, String.Empty, null);
                                break;
                            case "System.Int32":
                            case "System.Int64":
                            case "System.Int16":
                                prop.SetValue(LinqObj, 0, null);
                                break;
                            case "System.DateTime":
                                prop.SetValue(LinqObj, DateTime.Now, null);
                                break;
                        }
                    }
                }
            }
            catch
            {
                // could do something here ...
            }
        }
