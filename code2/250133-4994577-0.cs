	TestClass theClass = new TestClass();
	foreach (PropertyInfo property in theClass.GetType().GetProperties())
	{
		
		Console.WriteLine(property.Name);
		Console.WriteLine(property.GetValue(theClass, null));
	}
