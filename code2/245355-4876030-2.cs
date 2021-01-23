    class Example3
    {
        int _j;
        public int J
        {
            get { return _j; }
            set
            {
                _j = value;
                // and do something else,
                // to justify not using an auto-property 
            }
        }
        public Example3()
        {
            J = 0;
        }
        public int MethodWithParameter(int j)
        {
            // Now there is a *difference* between
            return j;
            // and
            return _j;
        }
    }
