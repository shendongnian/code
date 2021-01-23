    class Bar : Foo 
    {
        public Bar(int a, bool plusOrMinus) : base(a, calc(plusOrMinus))
        {
        }
        
        private static calc(bool pom) : ...; return -5; }
    }
