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
            public static void Main(string[] args)
            {
                A a = new A();
                Thread.Sleep(5000);
            }
        }
        class B
        {
            public B()
            {
                Task.Factory.StartNew(() =>
                {
                    Thread.Sleep(2000);
                    MyEvent("");
                });
            }
            public delegate void MyDelegate(string s);
            public event MyDelegate MyEvent;
        }
