    PropertyInfo GetImplementedProperty(PropertyInfo pi)
    {
        var type = pi.DeclaringType;
        var interfaces = type.GetInterfaces();
        if (interfaces.Length == 0) {
            return pi;
        }
            
        var flags = BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public;
        var query = from iface in interfaces
                    let implementedProperty = iface.GetProperty(pi.Name, flags)
                    where implementedProperty != pi
                    select implementedProperty;
        return query.DefaultIfEmpty(pi).First();
    }
