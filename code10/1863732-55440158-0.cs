    interface IMyClass
    {
        string MyProperty { get; } // this does nothing against implementing a setter!
    }
    
    abstract class MyAbstracClass : IMyClass
    {
        string MyProperty { get; protected set; } // otherwise we cannot set it from inheritors
    }
    
    class MyClass : MyAbstractClass
    {
        public new string MyProperty { get; set; } // nothing stops this!
        public MyClass (string prop) => MyProperty = prop;
    }
