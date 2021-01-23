    class A
    {
      public int BoardSize { get; protected set; }
    }
    class B : A
    {
      public B()
      {
        BoardSize = 100;
      }
    }
    class C : A
    {
      void SetBoardSize(int boardSize)
      {
        BoardSize = boardSize;
      }
    }
