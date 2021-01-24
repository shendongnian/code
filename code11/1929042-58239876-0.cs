        var derivedProperty = new DerivedProperty() { Name = "TestName", Description = "TestDescription" };
    // this one is not working, meaning derivedObject.Properties is always null
    var derivedObject = GetObjectInstance<DerivedClass, DerivedProperty>(derivedProperty);
    derivedObject.Properties.Dump();
	((BaseClass)derivedObject).Properties.Dump();
