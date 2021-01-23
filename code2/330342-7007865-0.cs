    static IMyInterface _myinterface;
    private static object lockObj = new object();
    public static IMyInterface someStuff
    {
       get
       {
          if (_myinterface== null)
          {
             lock(lockObj)
             {
                if (_myinterface== null)
                {             
                    _myinterface= MyServiceLocator.GetCurrent().GetInstance<IMyInterface>();
                }
             }
          }
          return _myinterface;
    }
