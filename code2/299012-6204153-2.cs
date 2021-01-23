     public void CheckData(object o)
     {
         PropertyInfo property = o.GetType().GetProperty("Test1");  //Get used to using public properties.
         string data = (string)property.GetValue(o, null);
     }
