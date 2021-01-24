      private static Task t = null;
      private static CancellationTokenSource cts = null;
      static void Main(string[] args)
      {
         [get arg]
         if (CanRedo(out var arg))
         {
            if (t != null)
            {
               cts.Cancel();
               t.Wait();
            }
            // Set up a new task and matching cancellation token
            cts = new CancellationTokenSource();
            t = Task.Run(() => liveTask(arg, cts.Token)); 
         }
      }
      private static void liveTask(object obj, CancellationToken ct)
      {
         string arg = obj.ToString();
         while(!ct.IsCancellationRequested)
         {
            if (bot._isDone)
            {
               ExecuteInstruction(arg);
            }
         }   
      }
Tasks are cancellable, and I can see nothing in your thread that requires the same physical thread to be re-used.
