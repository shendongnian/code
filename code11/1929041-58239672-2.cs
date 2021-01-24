    public TClass GetObjectInstance<TClass, TProperty>(TProperty properties)
    	where TClass : BaseClass<TProperty>, new()
    	where TProperty : BaseProperty
    {
    	var myObject = new TClass();
    	myObject.Properties = properties;
    	return myObject;
    }
