    class A
    {
        public int BoardSize { get {return GetBoardSize(); set {SetBoardSize(value); }
        protected abstract int GetBoardSize();
        protected abstract void SetBoardSize(int newSize);
        public abstract bool IsResizable { get; }
    }
    class B : A
    {
        public new int BoardSize { get {return GetBoardSize(); }
        protected override int GetBoardSize() { return 100; }
        protected override void SetBoardSize(int newSize)
            { throw new NotSupportedException("Board is not resizable."); }
        public override bool IsResizable { get {return false;} }
    }
