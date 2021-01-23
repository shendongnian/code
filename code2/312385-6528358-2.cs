    class MyNum
    {
        public MyNum(int num)
        {
            this.num = num;
        }
        // Add a default constructor that gets used by the subclasses:
        protected MyNum()
            : this(42)
        {
        }
    
