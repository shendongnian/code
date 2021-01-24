    public IEnumerable<string> FindRegisteredNames()
    {
        BindingFlags FindScopeFlags = BindingFlags.NonPublic | BindingFlags.Static;
        Type[] methodArgumentTypes = new Type[] { typeof(DependencyObject) };
        var FindScope = typeof(FrameworkElement).GetMethod("FindScope", FindScopeFlags, null, methodArgumentTypes , null);
    
        var result = FindScope.Invoke(null, new object[] { this });
        Type resultType = result.GetType();
        if (resultType.FullName == "System.Xaml.NameScope")
        {
            return (IEnumerable<string>)resultType.GetProperty("Keys").GetValue(result);
        }
        else
        {
            throw new NotSupportedException("Cannot detect registered names because FindScope returned unexpected type " + result.GetType().FullName);
        }
    }
