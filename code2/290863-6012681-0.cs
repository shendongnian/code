    interface I
    {
        object M();
    }
    
    class C
    {
        public some_type M() { return null; }
    }
    
    class D : C, I
    {
    }
