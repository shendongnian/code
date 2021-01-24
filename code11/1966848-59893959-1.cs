    void SomeMethod(ref SomeObject someObject)
    {
        someObject = new SomeObject(); // Assignment affects the outer scope due to ref
    }
    
    var someObject = new SomeObject();
    var sameObject = someObject;
    SomeMethod(someObject);
    bool same = someObject == sameObject; // false
