    // This will give you the setter, whatever its accessibility,
    // assuming it exists.
    MethodInfo setter = propInfo.GetSetMethod(/*nonPublic*/ true);
    
    if (setter != null)
    {
        // Just be aware that you're kind of being sneaky here.
        setter.Invoke(target, new object[] { value });
    }
