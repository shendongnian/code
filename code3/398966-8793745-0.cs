    DoWork(params object[] args)
    {
      //do the actual work
    }
    
    DoWork(IEnumerable<object> args)
    {
      DoWork(args.ToArray());
    }
        
    //etc etc
