      public bool ServerIsRunning
      {
         get => m_serverIsRunning;
         set
         {
            m_serverIsRunning = value;
            StartServer.RaiseCanExecuteChanged();
            StopServer.RaiseCanExecuteChanged();
         }
      }
