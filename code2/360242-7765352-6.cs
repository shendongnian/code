    /// <summary>
    /// Gets a total length of all string-type properties
    /// </summary>
    /// <param name="obj">The given object</param>
    /// <param name="anyAccessModifier">
    /// A value which indicating whether non-public and static properties 
    /// should be counted
    /// </param>
    /// <returns>A total length of all string-type properties</returns>
    public static int GetTotalLengthOfStringProperties(
                                      object obj, 
                                      bool anyAccessModifier)
    {
        Func<PropertyInfo, Object, int> resolveLength = (p, o) =>        
            ((((String) p.GetValue(o, null))) ?? String.Empty).Length;
    
        Type type = obj.GetType();
        IEnumerable<PropertyInfo> info = anyAccessModifier 
            ? type.GetProperties(BindingFlags.NonPublic | BindingFlags.Public | 
                                 BindingFlags.Instance | BindingFlags.Static)
            : type.GetProperties();    
    
        int total = info.Where(p => p.PropertyType == typeof (String))
                        .Sum(pr => resolveLength(pr, obj));
        return total;
    }
