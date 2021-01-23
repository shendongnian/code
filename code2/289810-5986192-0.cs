    void Run( Action<int> fn, int x )
    {
       fn(x);
    }
    void RunAndLog( Action<int> fn, int x )
    {
        print( "before " + x );
        fn(x);
        print( "after " + x );
    }
    void InvokeWorkerTenTimes( Action<Action<int>> gn, Action<int> fn )
    { 
        // fn is WHAT to do
        // gn is HOW to do it!
        for( int i=0; i<10; i++ )
            gn(fn, i);
    }
    void DoWork(int x)
    {
    }    
    void Main()
    {
        if( LoggingEnabled )
            InvokeWorkerTenTimes( RunAndLog, DoWork );
        else
            InvokeWorkerTenTimes( Run, DoWork );     
    }
