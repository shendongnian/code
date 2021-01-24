    public string FindRegisteredName(FrameworkElement control) {
        BindingFlags FindScopeFlags = BindingFlags.NonPublic | BindingFlags.Static;
        Type[] methodArgumentTypes = new Type[] { typeof(DependencyObject) };
        var FindScope = typeof(FrameworkElement).GetMethod("FindScope", FindScopeFlags, null, methodArgumentTypes, null);
    
        var result = FindScope.Invoke(null, new object[] { this });
        Type resultType = result.GetType();
        if (resultType.FullName == "System.Xaml.NameScope") {
            try {
                HybridDictionary map = (HybridDictionary)resultType.GetField("_nameMap", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(result);
                foreach (DictionaryEntry entry in map) {
                    if (entry.Value == control) {
                        return (string)entry.Key;
                    }
                }
            } catch (Exception) {
                throw new NotSupportedException("Cannot find registration name because internal structure has changed");
            }
        } else {
            throw new NotSupportedException("Cannot detect registered names because FindScope returned unexpected type " + result.GetType().FullName);
        }
    
        throw new KeyNotFoundException("Cannot find registered name of control.");
    }
