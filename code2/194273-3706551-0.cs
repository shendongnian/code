    PropertyInfo isReadOnly = typeof System.Collections.Specialized.NameValueCollection).GetProperty("IsReadOnly", BindingFlags.Instance| BindingFlags.NonPublic);
    //Remove the readonly property
    isReadOnly.SetValue(param, false, null);
    //.............put your code here
    
    //Set readonly property
    isReadOnly.SetValue(param, true, null);
