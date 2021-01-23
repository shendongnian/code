    interface Eq<T>
    {
        bool Equal(T a, T b);
        bool NotEqual(T a, T b);
    }
    interface Num<T> : Eq<T>
    {
        T Zero { get; }
        T Add(T a, T b);
        T Subtract(T a, T b);
        T Multiply(T a, T b);
        T Negate(T a);
    }
    sealed class Int : Num<int>
    {
        public static readonly Int Instance = new Int();
        private Int() { }
        public bool Equal(int a, int b) { return a == b; }
        public bool NotEqual(int a, int b) { return a != b; }
        public int Zero { get { return 0; } }
        public int Add(int a, int b) { return a + b; }
        public int Subtract(int a, int b) { return a - b; }
        public int Multiply(int a, int b) { return a * b; }
        public int Negate(int a) { return -a; }
    }
