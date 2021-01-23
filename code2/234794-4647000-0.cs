    if (_config == null)
    {
         thing = new MyThing();
    }
    else
    {
         thing = new MyThing(_config);
    }
    
    using (thing)
    {
    
        // do some stuff
    }
