	void Foo<T>(Expression<Func<T>> prop)
	{
		var propertyGetExpression = prop.Body as MemberExpression;
		
		// Display the property you are accessing, here "Height"
		propertyGetExpression.Member.Name.Dump();
		
		// "s" is replaced by a field access on a compiler-generated class from the closure
		var fieldOnClosureExpression = propertyGetExpression.Expression as MemberExpression;
		
		// Find the compiler-generated class
		var closureClassExpression = fieldOnClosureExpression.Expression as ConstantExpression;
		var closureClassInstance = closureClassExpression.Value;
		
		// Find the field value, in this case it's a reference to the "s" variable
		var closureFieldInfo = fieldOnClosureExpression.Member as FieldInfo;
		var closureFieldValue = closureFieldInfo.GetValue(closureClassInstance);
		
		closureFieldValue.Dump();
			
		// We know that the Expression is a property access so we get the PropertyInfo instance
		// And even access the value (yes compiling the expression would have been simpler :D)
		var propertyInfo = propertyGetExpression.Member as PropertyInfo;
		var propertyValue = propertyInfo.GetValue(closureFieldValue, null);
		propertyValue.Dump();
	}
	
	void Main()
	{
		string s = "Hello world";
		Foo(() => s.Length);
	}
