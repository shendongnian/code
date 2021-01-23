    void MethodA() {
     // Context in which CancellationTokenSource is known
     using (var tSource = new CancellationTokenSource()) {
      ThreadPool.QueueWorkItem( pArg => MethodB(tSource.Token) );
      ThreadPool.QueueWorkItem( pArg => MethodC(tSource.Token) );
      // ...
      // some other work to do
      // cancel
      if (mSomethingHappend) {
       tSource.Cancel();
      }
     }
    }
    
    private static void MethodB( CancellationToken pToken )
    {
     // ...
    }
