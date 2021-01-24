    using(var session = _sessionFactory.OpenSession()){
         using(var t = session.BeginTransaction()){
           try {
              //some code
              t.Commit();
           } catch(Exception ex){
              // Code the throws exception
              t.Rollback();
           } finally {
              // Some other code that throws exception
              // And then dispose
           }
         }
    }
