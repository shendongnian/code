    private void StoreSessionSpecific(Session dbSession, SessionViewModel session )
    {
       if (dbSession is LateSession) { 
          // handle as LateSession
       } else { 
          // handle as base-class Session
       }
    }
