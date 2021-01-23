    public class SomeType
    {
        string _A;
        string _B;
        string _C;
        
        public string A { get{return _A;}  set{ _A = value; _C = _A + _B; } }
        public string B { get{return _B;} set{ _B = value; _C = _A + _B; }
        public string C { get{return _C}; }
    }
