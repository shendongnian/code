    class STest : ITest<S>
    {
        public string t { get; private set; }
        string ITest.t { get { return t; } }
        public bool DoTest { ... }
    }
