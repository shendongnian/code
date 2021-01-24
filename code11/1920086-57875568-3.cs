    SomeClass class2 = new SomeClass();
    class2.Class = new SomeOtherClass();
    class2.Class.Test = "value";
    // will return the "value"
    string b = class2.IsNullOrEmpty();
