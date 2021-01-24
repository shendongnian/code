	private DynamicMetaObject BindGetOrInvokeMember(DynamicMetaObjectBinder binder, string name, bool ignoreCase, DynamicMetaObject fallback, Func<DynamicMetaObject, DynamicMetaObject> fallbackInvoke)
	{
		ExpandoClass @class = Value.Class;
		int valueIndex = @class.GetValueIndex(name, ignoreCase, Value);
		ParameterExpression parameterExpression = Expression.Parameter(typeof(object), "value");
		Expression test = Expression.Call(typeof(RuntimeOps).GetMethod("ExpandoTryGetValue"), GetLimitedSelf(), Expression.Constant(@class, typeof(object)), Expression.Constant(valueIndex), Expression.Constant(name), Expression.Constant(ignoreCase), parameterExpression);
		DynamicMetaObject dynamicMetaObject = new DynamicMetaObject(parameterExpression, BindingRestrictions.Empty);
		if (fallbackInvoke != null)
		{
			dynamicMetaObject = fallbackInvoke(dynamicMetaObject);
		}
		dynamicMetaObject = new DynamicMetaObject(Expression.Block(new ParameterExpression[1]
		{
			parameterExpression
		}, Expression.Condition(test, dynamicMetaObject.Expression, fallback.Expression, typeof(object))), dynamicMetaObject.Restrictions.Merge(fallback.Restrictions));
		return AddDynamicTestAndDefer(binder, Value.Class, null, dynamicMetaObject);
	}
	
