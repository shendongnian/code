    public BaseClass GetObject(int i)
    {
        if(i==1) return new DerivedClass();
        if(i==2) return new DerivedClass1();
    }
    
    BaseClass b = GetObject(1);
    b.Test(); // This will derivedclass method
    BaseClass b = GetObject(2);
    b.Test(); // This will derivedclass1 method
