    class Foo
    {
      int _answer;
      bool _complete;
     
      void A()
      {
        _answer = 123;
        Thread.MemoryBarrier();    // Barrier 1
        _complete = true;
        Thread.MemoryBarrier();    // Barrier 2
      }
     
      void B()
      {
        Thread.MemoryBarrier();    // Barrier 3
        if (_complete)
        {
          Thread.MemoryBarrier();       // Barrier 4
          Console.WriteLine (_answer);
        }
      }
    }
