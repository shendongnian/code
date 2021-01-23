    class Base
    {
        public int x = 3;
        public int GetValue() { return x * 5; }
    }
    class Derived : Base
    {
        public Derived()
        {
            x = 4;
        }
    }
