    public object Convert(object obj)
    {
        var bFlags = BindingFlags.Instance | BindingFlags.NonPublic;
        var parameterTypes = new[] { obj.GetType() };
        var method = typeof(CrmToRealTypeConverter)
                     .GetMethod("Convert", bFlags, null, parameterTypes, null);
     
        if (method == null)
            throw new ArgumentException("Unknown type");
    
        return method.Invoke(this, new object[] { obj });
    }  
 
