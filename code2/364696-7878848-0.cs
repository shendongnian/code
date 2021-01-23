    private static class RequestLimiter
    {
      private static AutoResetEvent _are = new AutoResetEvent(false);
      private static int _reqCnt = 0;
      public ResponseObject DoRequest(RequestObject req)
      {
        for(;;)
        {
          if(Interlocked.Increment(ref _reqCnt) <= 5)
          {
            //code to create response object "resp".
            Interlocked.Decrement(ref _reqCnt);
            _are.Set();
            return resp;
          }
          else
          {
              if(Interlocked.Decrement(ref _reqCnt) >= 5)//test so we don't end up waiting due to race on decrementing from finished thread.
               _are.WaitOne();
          }
        }
      }
    }
