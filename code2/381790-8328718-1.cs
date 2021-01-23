    class X1 : X
    {
        public X1(H1 h) : base(h) { }
    
        public new H1 HValue 
        { 
            get { return (H1)base.HValue; }
        }
    }
