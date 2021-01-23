    BaseClass instance = new DerivedClass();
    
    System.Type type = instance.GetType();
    
    if ((typeof(BaseClass)).IsAssignableFrom(type))    // returns true
    {
    }
