    class A 
    {
        protected void Foo(){}
    }
    
    class B : A 
    {
        public new void Foo()
        {
            base.Foo()
        }
    }
