    interface IB
    {
        int SomeMethod();
    }
    class B : IB
    {
        public int SomeMethod() { return 3; }
    }
    class ABAdapter : IB
    {
        private A a; 
        public ABAdapter(A a) { this.a = a; }
        public int SomeMethod() { return a.SomeMethod(); } 
    }
