    var someObject = new SomeClass();
    var sameObject = someObject; // still the same object
    SomeMethod(someObject); // now a new object
    bool theSame = someObject == sameObject; // false
    
    void SomeMethod(ref SomeClass someObject)
    {
        SomeClass insideMethod = someObject; // still the same object
        someObject = new SomeObject();
    }
