    class foo
    {
        public virtual string Name
        {
            get
            {
                return "fooname";
            }
        }
    }
    class bar : foo
    {
        public override string Name
        {
            get
            {
                return "barname";
            }
        }
    }
