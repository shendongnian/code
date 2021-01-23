    public static bool? IsVirtual(this PropertyInfo self)
    {
        if (self == null)
            throw new ArgumentNullException("self");
    
        bool? found = null;
    
        foreach (MethodInfo method in self.GetAccessors()) {
            if (found.HasValue) {
                if (found.Value != method.IsVirtual)
                    return null;
            } else {
                found = method.IsVirtual;
            }
        }
    
        return found;
    }
