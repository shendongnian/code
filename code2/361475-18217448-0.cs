    class Base
    {
        public virtual Base Method () { return this ; }
    }
    class Derived1: Base 
    { 
        public new Derived1 Method () { return this ; }
    }
    class Derived2: Base
    {
        public new Derived2 Method () { return this ; }
    }
