    using System;
    
    public class BaseClass
    {
        public BaseClass(object param)
        {
            // base constructor
        }
    }
    
    public class DerivedClass : BaseClass
    {
        public DateTime Date { get; private set; }
        public DerivedClass() : this(new object()) { }
        public DerivedClass(object param) : base(param)
        {
            //Do the data stuff here
            //Had to cut your pseudo code, as it broke compilation
        }
    }
