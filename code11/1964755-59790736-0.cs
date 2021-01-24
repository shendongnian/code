    var someObject = new SomeClass();
    var sameObject = SomeMethod(someObject); // still the same object
    bool theSame = someObject == sameObject; // true
    
    SomeClass SomeMethod(SomeClass someObject)
    {
        SomeClass insideMethod = someObject; // still the same object
        return insideMethod; // return object passed to method
    }
