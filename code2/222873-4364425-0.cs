    public struct MyTest
    {
        string me;
        public MyTest(string v) { me = v; }
        public static implicit operator string(MyTest v) { return v.me; }
        public static implicit operator MyTest(string v) { return new MyTest(v); }
        public override string ToString() { return me; }
    }
