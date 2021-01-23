    class Base
        {
            public Base(int x) { }
        }
        class Derived : Base
        {
            public Derived(int x)
                : base(x)
            {
            }
        }
