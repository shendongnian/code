    static IMyObj MyFunc(out IMyObj obj)
    {
      Statement1();
      obj = GetObj();
      Statement2();
    }
    class C1
    {
      void SomeFunc
      {
        IMyObj obj=null;
        try
        {
             MyFunc(out obj);
        }
        finally
        {
            Obj = obj;
        }
      }
      IMyObj Obj{get;private set;}
    }
