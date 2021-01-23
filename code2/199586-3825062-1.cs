      while (worker.IsBusy)
      {
         Dispatcher.CurrentDispatcher.Invoke(DispatcherPriority.Background,new EmptyDelegate(delegate{}));
         //Application.DoEvents();
         System.Threading.Thread.Sleep(10);
      }
