    public class D : A
    {
        private D(B b) : base(b)
        {
        }
        
        public static D Get(DerivedFromB1 b) => new D(b);
        public static D Get(DerivedFromB2 b) => new D(b);
    }
