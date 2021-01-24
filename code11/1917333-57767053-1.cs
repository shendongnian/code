    // does not necessarily work as expected if the property or one of its accessors
    // (getter or setter) is not public
    internal static bool CanReadExt(PropertyInfo pi)
    {
      if (pi.CanRead)
        return true;
      // assume we have a setter since we do not have a getter
      var setter = pi.SetMethod;
      // try to get setter of base property
      var baseSetter = setter.GetBaseDefinition();
      // if the property was not overridden, we can return
      if (setter.DeclaringType == baseSetter.DeclaringType)
        return false;
      // try to find the base property
      var basePi = baseSetter.DeclaringType.GetProperties()
        .SingleOrDefault(x => x.SetMethod == baseSetter)
        ?? throw new Exception("Set accessor was overridden but could not find property info for base property.");
      // recursively call ourself
      return CanReadExt(basePi);
    }
