    public void copyAttrs(List<string> props, ref Class2 source, ref Class2 dest)
    {
        BindingFlags _flags = BindingFlags.GetProperty | BindingFlags.IgnoreCase |
                                BindingFlags.Instance | BindingFlags.Static |
                                BindingFlags.Public | BindingFlags.NonPublic |
                                BindingFlags.FlattenHierarchy;
        foreach (string prop in props)
        {
            var propSource = source.GetType().GetProperty(prop, _flags);
            var proDest = dest.GetType().GetProperty(prop,_flags);
            if ((propDest != null) && (propSource != null))
            {
                MethodInfo destSetMethod = propDest.GetSetMethod();
                MethodInfo sourceGetMethod = propSource.GetGetMethod();
                if ((destSetMethod != null) && (sourceGetMethod != null))
                    destSetMethod.Invoke(dest, new object[] { sourceGetMethod.Invoke(source, null) });
            }
        }
    }
