    void Print<T>(T val)
    {
      switch(T.GetType())
      {
        case typeof(UInt64):
             Console.WriteLine(...); break;
      }
    }
