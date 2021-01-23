    class foo
    {
        protected string name = "fooname";
        public string getName()
        {
            return this.name;
        }
    }
    class bar : foo
    {
        public bar()
        {
            name = "barname";
        }
    }
