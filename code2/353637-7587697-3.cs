    public void SomeFunction(BaseClass instanceOfDerivedClass)
    {
        DerivedClass derived = instanceOfDerivedClass as DerivedClass;
    
        if(derived != null)
        {
            // Do stuff like :
            int prop = derived.DerivedProperty;
        }
    }
