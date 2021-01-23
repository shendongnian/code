     Action action = () = > DoSomething();
     action.BeginInvoke(OnComplete, null);
     private void OnComplete(IAsyncResult ar)
     {
         AsyncResult result = (AsyncResult)ar;
         var caller = (Action)result.AsyncDelegate;
         caller.EndInvoke();
         // do something else when completed
     }
