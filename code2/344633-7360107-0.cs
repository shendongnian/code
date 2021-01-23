    public ISession GetCurrentSession()
    {
            HttpContext context = HttpContext.Current;
    
            var currentSession = context.Items["session"] as ISession;
    
            if( currentSession is null )
            {
                 currentSession = SessionFactory.GetCurrentSession()
                 context.Items["session"] = currentSession;
            }
    
            return currentSession;
    }
