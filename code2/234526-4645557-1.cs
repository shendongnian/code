    private PropertyInfo GetRootProperty(PropertyInfo pi)
        {
            if ((pi.GetGetMethod().Attributes & MethodAttributes.Virtual) != MethodAttributes.Virtual) { return pi; }
            var type = pi.DeclaringType;
            while (true)
            {
                type = type.BaseType;
                if (type == null)
                {
                    return pi;
                }
                var flags = BindingFlags.NonPublic | BindingFlags.DeclaredOnly | BindingFlags.Instance |
                            BindingFlags.Public | BindingFlags.Static;
                var inheritedProperty = type.GetProperty(pi.Name, flags);
                if (inheritedProperty == null)
                {
                    return pi;
                }
                pi = inheritedProperty;
            }
        }
