    void Print<T>(T val)
    {
      switch(val.GetType())
      {
        case typeof(UInt64):
             Console.WriteLine(...); break;
      }
    }
