    class Example1
    {
        public int J { get; set; }
        public Example1()
        {
            J = 0;
        }
        // These two methods have *exactly* the same CIL
        public int InstanceMethodLong()
        {
            return this.J;
        }
        public int InstanceMethodShort()
        {
            return J;
        }
    }
