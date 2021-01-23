	private void SetPropertyValue(Expression<Func<object, object>> lambda, object value)
	{
		var memberExpression = (MemberExpression)lambda.Body;
		var propertyInfo = (PropertyInfo)memberExpression.Member;
		var propertyOwnerExpression = (MemberExpression)memberExpression.Expression;
		var propertyOwner = Expression.Lambda(propertyOwnerExpression).Compile().DynamicInvoke();
	   
		propertyInfo.SetValue(propertyOwner, value, null);            
	}
    ...
    SetPropertyValue(s => myStuff.MyPropy, newValue);
