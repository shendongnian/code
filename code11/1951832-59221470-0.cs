    public T GetAttribute<T>(Enum _enum) where T : Attribute
    {
    	return 
    		(T)_enum.GetType()
    				.GetField(Enum.GetName(_enum.GetType(), _enum))
    				.GetCustomAttribute(typeof(T));
    }
