    class X
    {
        private int y;
        public int Y
        {
            get { return y; }
            set { y = value; }
        }
        public X(int number)
        {
            Y = number;
            //equivalent to 
            y = number;
            // but you should use the public property setter instead of the private field
        }
    }
