    public static byte[] GetILBytes(DynamicMethod dynamicMethod)
    {
        var resolver = typeof(DynamicMethod).GetField("m_resolver", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(dynamicMethod);
        if (resolver == null) throw new ArgumentException("The dynamic method's IL has not been finalized.");
        return (byte[])resolver.GetType().GetField("m_code", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(resolver);
    }
