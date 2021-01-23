    /// <summary>
    /// Gets a total length of all string-type properties
    /// </summary>
    /// <param name="obj">The given object</param>
    /// <param name="anyAccessModifier">
    /// A value which indicating whether non-public and static properties 
    /// should be counted
    /// </param>
    /// <returns>A total length of all string-type properties</returns>
    public static int GetPropertiesMaxLength(object obj, bool anyAccessModifier)
    {
        Func<PropertyInfo, bool, int> resolveLength = (p, any) => 
           ((any
            ? ((String) p.GetValue(
                obj,
                BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static,
                null,
                null,
                null))
            : ((String) p.GetValue(obj, null))) ?? String.Empty).Length;
    
        Type type = obj.GetType();
        PropertyInfo[] info = type.GetProperties();    
        int total = info.Where(p => p.PropertyType == typeof (String))
                        .Sum(pr => resolveLength(pr, anyAccessModifier));
        return total;
    }
