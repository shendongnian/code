	private static bool DynamicCast(object source, Type destType, out object result)
	{
		Type srcType = source.GetType();
		if (srcType == destType) { result = source; return true; }
		result = null;
		BindingFlags bf = BindingFlags.Static | BindingFlags.Public;
		MethodInfo castOperator = destType.GetMethods(bf)
									.Union(srcType.GetMethods(bf))
									.Where(mi => mi.Name == "op_Explicit" || mi.Name == "op_Implicit")
									.Where(mi =>
									{
										var pars = mi.GetParameters();
										return pars.Length == 1 && pars[0].ParameterType == srcType;
									})
									.Where(mi => mi.ReturnType == destType)
									.FirstOrDefault();
		if (castOperator != null) result = castOperator.Invoke(null, new object[] { source });
		else return false;
		return true;
	}
