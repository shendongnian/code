    class B : A
    {
        public B() { }
        public B(A original)
        {
            // copy values from original to this
        }
        public int Number { get; private set; }
    }
