    public class Initializer
    {
        public Initializer(int b)
        {
            A = "(unknown)";
            B = b;
        }
        public string A { get; set; }
        public int B { get; private set; }
        public DoSomeActionParameters Create()
        {
            if (B < 50) throw new ArgumentOutOfRangeException("B");
            return new DoSomeActionParameters(this);
        }
    }
