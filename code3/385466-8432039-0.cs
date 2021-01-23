    var subPropertyInfo = typeof(SubClass).GetProperty("Id");
    var subPropertyInfoSetter = subPropertyInfo.GetSetMethod();
    var basePropertyInfo = typeof(Base).GetProperty("Id");
    var basePropertyInfoSetter = basePropertyInfo.GetSetMethod();
    Console.WriteLine(subPropertyInfo == basePropertyInfo);		// false
    Console.WriteLine(subPropertyInfoSetter == basePropertyInfoSetter);	// false
