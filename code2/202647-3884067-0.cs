    class A
    {
        public virtual int P1
        {
            get { return 42; }
            set { }
        }
    }
    class B : A
    {
        public override int P1
        {
            get { return 18; }
        }
    }
 
