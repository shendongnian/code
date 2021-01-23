    class X
    {
        private string _a;
        public string A { get { return _a; } }
    
        private string _b;
        public string B { get { return _b; } }
    
        public X(string a, string b)
        {
            _a = a;
            _b = b;
        }
    }
--
    abstract class ABase
    {
        abstract public string A { get; }
    }
    
    interface IB
    {
        string B { get; }
    }
    
    class My : ABase, IB
    {
        private string _a;
        public override A : string { get { return _a; } }
    
        private string _b;
        public virtual  B : string { get { return _b; } }
    
        public My(string a, string b)
        {
            _a = a;
            _b = b;
        }
    }
