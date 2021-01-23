    using System;
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    class BaseAttribute : Attribute {
    }
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    class Derived1Attribute : BaseAttribute {
    }
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    class Derived2Attribute : BaseAttribute {
    }
    [Derived1]
    [Derived2] // this one is ok
    class DoubleDerived {
    }
