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
        INewable<int> cn1; // ALLOWED: has parameterless ctor
        INewable<string> n2; // NOT ALLOWED: no parameterless ctor
        INewable<MyStruct> n3; // ALLOWED: has parameterless ctor
        INewable<MyClass1> n4; // ALLOWED: has parameterless ctor
        INewable<MyClass2> n5; // ALLOWED: has parameterless ctor
        INewable<MyClass3> n6; // NOT ALLOWED: no parameterless ctor
        INewable<MyClass4> n7; // ALLOWED: has parameterless ctor
        INewableReference<int> nr1; // NOT ALLOWED: not a reference type
        INewableReference<string> nr2; // NOT ALLOWED: no parameterless ctor
        INewableReference<MyStruct> nr3; // NOT ALLOWED: not a reference type
        INewableReference<MyClass1> nr4; // ALLOWED: has parameterless ctor
        INewableReference<MyClass2> nr5; // ALLOWED: has parameterless ctor
        INewableReference<MyClass3> nr6; // NOT ALLOWED: no parameterless ctor
        INewableReference<MyClass4> nr7; // ALLOWED: has parameterless ctor
    }
