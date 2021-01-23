    var type = this.GetType();
    foreach(var prop in 
        type.GetProperties(BindingFlags.Instance | BindingFlags.NonPublic))
    {
        var attr = prop.GetCustomAttributes(typeof(SaveInStateAttribute), true);
        if(attr.Length > 0)
        {
            // Add the attributes to your collection
        }
    }
