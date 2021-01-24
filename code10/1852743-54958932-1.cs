    class Base
    {
        private bool X;
        protected bool Y;
    }
    class A : Base
    {
        public void Foo()
        {
            X = false; //error: cannot access private member.
            Y = true; //can access protected member, but only from classes with `: Base`
        }
    }
    class B
    {
        public void Foo()
        {
            A a = new A();
            
            a.X = false; //error: cannot access private member.
            a.Y = false; //error: cannot access protected member.
        }
    }
