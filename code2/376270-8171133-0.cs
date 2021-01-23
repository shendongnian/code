    void Main()
    {
    	BE be  = new BE();
    	SetMyPropertyValue("RFID", be, 2);
    	SetMyPropertyValue("CUSIP", be, "hello, world");
    	
    	Console.WriteLine(be.RFID.PropertyValue);
    	Console.WriteLine(be.CUSIP.PropertyValue);
    }
    
    private void SetMyPropertyValue(string propertyName, object instance, object valueToSet) 
    {
    	Type be = instance.GetType();
    	Type valueType = valueToSet.GetType();
    	Type typeToSet = typeof(MyProperty<>).MakeGenericType(valueType);
    	object value = Activator.CreateInstance(typeToSet,valueToSet);
    	
    	var prop = be.GetProperty(propertyName);
    	prop.SetValue(instance, value, null);
    }
