        class A
        {
            private B b;
            public A()
            {
                b = new B();
                b.MyEvent += MyHandler;
            }
            public void MyHandler(string s)
            {
            }
        }
        class B
        {
            public delegate void MyDelegate(string s);
            public event MyDelegate MyEvent;
        }
