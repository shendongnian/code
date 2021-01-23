    class Base
    {
        public virtual string Foo
        {
            get;
            set;
        }
    }
    
    class Derived : Base
    {
        public override string Foo
        {
            get {
                // Return something else...
            }
            set {
                // Do something else...
            }
        }
    }
