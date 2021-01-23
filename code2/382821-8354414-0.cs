    var fields = typeof(DateTime).GetFields(
        BindingFlags.Public | BindingFlags.Instance);
    
    var properties = typeof(DateTime).GetProperties(
        BindingFlags.Public | BindingFlags.Instance);
    
    var all = fields.Cast<MemberInfo>().Concat(properties.Cast<MemberInfo>());
    
    foreach (MemberInfo mi in all)
    {
        //some code
    }
