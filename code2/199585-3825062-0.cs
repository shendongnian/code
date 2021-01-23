      while (worker.IsBusy)
      {
         Application.DoEvents();
         System.Threading.Thread.Sleep(10);
      }
