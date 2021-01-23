    foreach(PropertyInfo pi in myobject.GetType().GetProperties(BindingFlags.Public))
    {
        if (pi.GetValue(myobject)==null)
        {
            // do something
        }
    }
