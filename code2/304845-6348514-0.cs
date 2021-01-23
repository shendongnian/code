      public void Method1(Backgroundworker worker)
      {
         foreach (var discard in Method1Steps)
         {
            if (worker.CancelationPending)
               return;
         }
      }
    
      private IEnumerable<object> Method1Steps()
      {
         for (int i = 0; i < 10; ++i)
         {
            yield return null;
            Console.WriteLine("A");
            for (int j = 0; j < 100; ++i)
            {
               Thread.Sleep(100);
               yield return null;
            }
         }
      }
