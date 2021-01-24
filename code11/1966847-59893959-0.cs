    void SomeMethod(SomeObject someObject)
    {
        someObject = new SomeObject(); // Assignment is only local to the method scope
    }
    
    var someObject = new SomeObject();
    var sameObject = someObject;
    SomeMethod(someObject);
    bool same = someObject == sameObject; // true
