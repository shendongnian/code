    class BasicWaitHandle
    {
       static EventWaitHandle _waitHandle = new AutoResetEvent (false);
       static void Main()
       {
           new Thread (Waiter).Start();        
           _waitHandle.WaitOne(); //wait for notification
           //Do operartion
       }
       static void Waiter()
       {
          //Do operations
          _waitHandle.Set(); //Unblock
       }
    }
