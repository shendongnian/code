    class Foo {
        private int c;
    
        public Foo(int a, int b) {
            c = a + b;
        }
    }
    
    class Bar {
        private Foo _base;
    
        public Bar(int a, bool plusOrMinus) {
            if (plusOrMinus) {
                _base = new Foo(a, 5);
            } else {
                _base = new Foo(a, -5);
            }
        }
    }
