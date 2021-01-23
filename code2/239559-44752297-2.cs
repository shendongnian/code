    struct MyStruct { } // structs are value types
    class MyClass1 { } // no constructors defined, so the class implicitly has a parameterless one
    class MyClass2 // parameterless constructor explicitly defined
    {
        public MyClass2() { }
    }
    class MyClass3 // only non-parameterless constructor defined
    {
        public MyClass3(object parameter) { }
    }
    class MyClass4 // both parameterless & non-parameterless constructors defined
    {
        public MyClass4() { }
        public MyClass4(object parameter) { }
    }
    interface INewable<T>
        where T : new()
    {
    }
    interface INewableReference<T>
        where T : class, new()
    {
    }
    class Checks
    {
        INewable<int> cn1; // ALLOWED
        INewable<string> n2; // NOT ALLOWED: string does not have a parameterless constructor
        INewable<MyStruct> n3; // ALLOWED
        INewable<MyClass1> n4; // ALLOWED
        INewable<MyClass2> n5; // ALLOWED
        INewable<MyClass3> n6; // NOT ALLOWED: MyClass3 does not have a parameterless constructor
        INewable<MyClass4> n7; // ALLOWED
        INewableReference<int> nr1; // NOT ALLOWED: int is not a reference type
        INewableReference<string> nr2; // NOT ALLOWED: string does not have a parameterless constructor
        INewableReference<MyStruct> nr3; // NOT ALLOWED: structs are not reference types
        INewableReference<MyClass1> nr4; // ALLOWED
        INewableReference<MyClass2> nr5; // ALLOWED
        INewableReference<MyClass3> nr6; // NOT ALLOWED: MyClass3 does not have a parameterless constructor
        INewableReference<MyClass4> nr7; // ALLOWED
    }
