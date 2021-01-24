    class FooState
    {
        private int _a;
    
        public int A
        {
            get { return _a; }
            set
            {
                _a = value;
                Update();
            }
        }
    
        private int _b;
    
        public int B
        {
            get { return _b; }
            set
            {
                _b = value;
                Update();
            }
        }
    
        public double C { get; private set; }
    
        // other members
    
        private void Update()
        {
            C = A * B + 3;
            // other updates
        }
    }
    
    class Foo
    {
        private FooState _state;
    
        public Foo()
        {
            _state.A = 1;
            _state.B = 2;
            Debug.Write($"C = {_state.C}");
        }
    }
