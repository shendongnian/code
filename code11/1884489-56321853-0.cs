    class Obj {
        private long pos;
        public ref long Position { get { return ref pos; } }
    }
    static void Main(string[] args)
    {
        Obj a = new Obj();
        Obj a2 = new Obj();
        a.Position = 10;
        a2.Position = 20;
        Swap<long>(ref a.Position, ref a2.Position);
    }
