    class Base
    {
        virtual void M() { }
    }
    class Derived : Base
    {
        override void M() { }
        override void Base.M() { }
    }
