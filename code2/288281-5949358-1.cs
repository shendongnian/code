    class A
    {
      int _boardSize;
      protected A(int boardSize)
      {
        _boardSize = boardSize;
      }
      public int BoardSize
      {
        get { return _boardSize; }
      }
    }
    class B : A
    {
      public B() : base(100) { }
    }
