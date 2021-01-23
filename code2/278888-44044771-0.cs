    class R {
        public int A { get; set; }
    }
    class R1: R {
        public int B { get; set; }
    }
    class A
    {        
        public R X { get; set; }
    }
    class B : A 
    {
        private R1 _x;
        public new R1 X { get => _x; set { ((A)this).X = value; _x = value; } }
    }
