    public void SomeFunction(BaseClass instanceOfDerivedClass)
    {
        DerivedClass derived = null;
    
        if(instanceOfDerivedClass is DerivedClass)
        {
            derived = instanceOfDerivedClass as DerivedClass;
            // Do stuff like :
            int prop = derived.DerivedProperty;
        }
    }
