    // Example 1:
    SomeClass someObject;
    if(x == y)
    {
        someObject = new SomeClass();
    }
    someObject.someMethod();   //Error since it may not execute the if statements
    // Example 2
    SomeClass someObject;
    someObject = new SomeClass();
    someObject.someMethod();   //No Error
    
    
