    abstract class B 
    {
        protected abstract Animal ProtectedM();
        public Animal Animal { get { return this.ProtectedM(); } }
    }
    class D : B
    {
        protected override Animal ProtectedM() { return new Tiger(); }
        public new Tiger Animal { get { return (Tiger)this.ProtectedM(); } }
    }
