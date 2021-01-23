    PropertyInfo GetRootProperty(PropertyInfo pi)
    {
        var type = pi.DeclaringType;
        while (true) {
            type = type.BaseType;
            if (type == null) {
                return pi;
            }
            var flags = BindingFlags.NonPublic | BindingFlags.DeclaredOnly | BindingFlags.Instance |
                        BindingFlags.Public | BindingFlags.Static;
            var inheritedProperty = type.GetProperty(pi.Name, flags);
            if (inheritedProperty == null) {
                return pi;
            }
            pi = inheritedProperty;
        }
    }
