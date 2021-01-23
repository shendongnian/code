    private object SafeUnproxy(dynamic item)
    {
        // ProxyCreation is off, so any reference or collection properties may not yet be loaded. We need to make sure we explicitly load each property from the db first.
        ExplicitlyLoadMembers(item);
        // Figure out the right type to use as the explicit generic type argument
        var itemType = item.GetType();
        Type requiredPocoType = (itemType.Namespace == "System.Data.Entity.DynamicProxies") ?
                                                                    itemType.BaseType :
                                                                    itemType;
    
        // Call Unproxy using an explicit generic type argument
        var unproxiedValue = typeof(VerhaalLokaalDbContext).GetMethod("UnProxy").MakeGenericMethod(requiredPocoType).Invoke(this, new[] { item });
        return unproxiedValue;
    }
