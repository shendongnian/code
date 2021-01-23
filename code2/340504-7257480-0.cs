    enum Example
    {
      None      = 0,            //  0
      Alpha     = 1 << 0,       //  1
      Beta      = 1 << 1,       //  2
      Gamma     = 1 << 2,       //  4
      Delta     = 1 << 3,       //  8
      Epsilon   = 1 << 4,       // 16
      All       = ~0,           // -1
      AlphaBeta = Alpha | Beta, //  3
    }
