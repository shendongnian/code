    public partial class Test
    {
        public Test() { }
        public partial class InsideClass
        {
            public InsideClass() { }
            public void PublicMethod() => PrivateHelper();
        }
    }
