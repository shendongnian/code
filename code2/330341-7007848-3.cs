    private static readonly object m_lock = new object();
    private static IMyInterface _myinterface;
    public static IMyInterface someStuff
    {
        get
        {
            lock(m_lock)
            {
               if (_myinterface == null)
               {
                 //create instance
               }
               return _myinterface;
            }            
        }
    }
