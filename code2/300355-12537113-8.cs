    public class DoSomeActionParameters
    {
        readonly string _a;
        readonly int _b;
        public string A { get { return _a; } }
        public int B{ get { return _b; } }
        DoSomeActionParameters(Initializer data)
        {
            _a = data.A;
            _b = data.B;
        }
        public class Initializer
        {
            public Initializer()
            {
                A = "(unknown)";
                B = 88;
            }
            public string A { get; set; }
            public int B { get; set; }
        }
        public static DoSomeActionParameters Create(Action<Initializer> assign)
        {
            var i = new Initializer();
            assign(i)
            return new DoSomeActionParameters(i);
        }
    }
