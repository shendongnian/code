    private object m_lock = new object();
    static IMyInterface _myinterface;
    public static IMyInterface someStuff
    {
        get
        {
            if (_myinterface== null)
            {
                lock(m_lock)
                {
                   if (_myinterface== null)
                   {
                     //create instance
                   }
                }
            }
    
            return _myinterface;
        }
    }
