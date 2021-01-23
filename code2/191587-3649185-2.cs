    class base1
    {
        public virtual string navUrl
        {
            get;
            set;
        }
    }
    
    class derived : base1
    {
        public new string navUrl
        {
            get;
            set;
        }
    }
