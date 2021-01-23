    /// <summary>
    /// Returns <see langword="true" /> if the user is allowed to read the
    /// calling property.
    /// </summary>
    /// <param name="property">Property to check.</param>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public virtual bool CanReadProperty(Csla.Core.IPropertyInfo property)
    {
      bool result = true;
      VerifyAuthorizationCache();
      if (!_readResultCache.TryGetValue(property.Name, out result))
      {
        result = BusinessRules.HasPermission(AuthorizationActions.ReadProperty, property);
        // store value in cache
        _readResultCache[property.Name] = result;
      }
      return result;
    }
