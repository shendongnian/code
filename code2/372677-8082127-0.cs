    using System;
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    class BaseAttribute : Attribute {
    }
    [Base]
    [Base] // compiler error here
    class DoubleBase { 
    }
