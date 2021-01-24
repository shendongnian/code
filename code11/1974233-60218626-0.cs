	public static Test ConstructTest(int? i = null)
	{
        // find the constructor that takes an `int`:
		ConstructorInfo constructorMethod = typeof(Test).GetConstructor(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance, null, new Type[] { typeof(int) }, null);
		if (constructorMethod == null)
		{
			throw new Exception("desired constructor not found"); // replace with specific exception
		}
		
		ParameterInfo iParameter = constructorMethod.GetParameters().Single();
		if (!i.HasValue && !iParameter.HasDefaultValue)
		{
			throw new Exception("no parameter specified, no default value"); // replace with specific exception
		}
		i = i ?? (int)iParameter.DefaultValue; // use the supplied parameter or the default value
		return (Test)constructorMethod.Invoke(new object[] { i }); // invoke the constructor
	}
