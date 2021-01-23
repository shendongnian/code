    class Base
    {
        public int x = 3;
        private int xAndFour;
        public Base()
        {
            xAndFour = x + 4;
        }
        public int GetValue() { return xAndFour; }
    }
    class Derived : Base
    {
        public Derived()
        {
            x = 4;
        }
    }
