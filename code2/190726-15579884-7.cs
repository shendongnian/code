	var listTo = ReflectionHelper.GetIEnumerableType(
		fromValue.GetType());
	var fn = new Func<
		IEnumerable<object>,
		Func<PropertyInfo, bool>,
		Dictionary<Type, Type>,
		IEnumerable<object>>(
			ModelTransform.CopyList<object>);
	var copyListMethod = fn.GetMethodInfo()
		.MakeGenericMethod(listTo);
	copyListMethod.Invoke(null,
		new object[] { fromValue, whereProps, typeMap });
