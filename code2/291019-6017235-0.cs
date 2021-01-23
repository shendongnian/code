    void MethodA ()
    {
        using (IUnitOfWork uow = UnitOfWork.Current)
        {
            // do some query here
        }
    }
    
    void MethodB ()
    {
        using (IUnitOfWork uow = UnitOfWork.Current)
        {
            // do another query here
        }
    }
    MethodA (); // works OK
    // now UnitOfWork.Current is disposed
    MethodB ();  // raises exception
