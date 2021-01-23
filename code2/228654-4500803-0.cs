    class A {
        public event EventHandler SomeEvent;
    }
    
    class B {
        public B(A a) {
            a.SomeEvent += (sender, e) => { Console.WriteLine("B's handler"); };
        }
    }
    
    class C {
        public C(A a) {
            a.SomeEvent += (sender, e) => { Console.WriteLine("C's handler"); };
        }
    }
