    struct MyStruct { } // structs are value types
    class MyClass1 { } // no constructors are defined, so the class implicitly has a parameterless one
    class MyClass2 // a parameterless constructor is explicitly defined
    {
        public MyClass2() { }
    }
    class MyClass3 // a constructor is defined but it is not parameterless
    {
        public MyClass3(object parameter) { }
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
        ICheckNewable<MyClass3> cn5; // NOT ALLOWED: MyClass3 does not have a parameterless constructor
        ICheckNewableReference<int> cnr1; // NOT ALLOWED: int is value type
        ICheckNewableReference<string> cnr2; // ALLOWED
        ICheckNewableReference<MyStruct> cnr3; // NOT ALLOWED: structs are value types
        ICheckNewableReference<MyClass1> cnr4; // ALLOWED
        ICheckNewableReference<MyClass3> cnr5; // ALLOWED
    }
