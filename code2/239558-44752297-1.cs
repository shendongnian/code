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
    interface ICheckNewable<T>
        where T : new()
    {
    }
    interface ICheckNewableReference<T>
        where T : class
    {
    }
    class NewableChecker
    {
        ICheckNewable<int> cn1; // ALLOWED
        ICheckNewable<string> cn2; // NOT ALLOWED: string does not have a parameterless constructor
        ICheckNewable<MyStruct> cn3; // ALLOWED
        ICheckNewable<MyClass1> cn4; // ALLOWED
        ICheckNewable<MyClass2> cn5; // ALLOWED
        ICheckNewable<MyClass3> cn6; // NOT ALLOWED: MyClass3 does not have a parameterless constructor
        ICheckNewable<MyClass4> cn7; // ALLOWED
        ICheckNewableReference<int> cnr1; // NOT ALLOWED: int is value type
        ICheckNewableReference<string> cnr2; // ALLOWED
        ICheckNewableReference<MyStruct> cnr3; // NOT ALLOWED: structs are value types
        ICheckNewableReference<MyClass1> cnr4; // ALLOWED
        ICheckNewableReference<MyClass2> cnr5; // ALLOWED
        ICheckNewableReference<MyClass3> cnr6; // ALLOWED
        ICheckNewableReference<MyClass4> cnr7; // ALLOWED
    }
