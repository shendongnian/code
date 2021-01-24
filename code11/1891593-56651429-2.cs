    public static IEnumerable<MethodInfo> DerivedMethods(this MethodInfo mi)
    {
		Type baseType = mi.DeclaringType;
		IEnumerable<Type> subClasses = baseType.Assembly.GetTypes().Where((klass) => klass != baseType && baseType.IsAssignableFrom(klass));
		if (baseType.IsInterface) {
	        return from klass in subClasses
			       where !klass.IsInterface
				   let map = klass.GetInterfaceMap(baseType)
				   select map.TargetMethods[Array.IndexOf(map.InterfaceMethods, mi)];
		}
		else {
	        return from klass in subClasses
			       where !klass.IsAbstract // include this only if you want instantiable classes
				   from m in klass.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
				   where m.GetBaseDefinition() == mi.GetBaseDefinition()
				   select m;
		}
    }
