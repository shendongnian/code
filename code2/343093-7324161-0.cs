      protected ManualResetEvent _resetEvent = new ManualResetEvent(false);
      public void WaitingThread()
      {
          _resetEvent.WaitOne();
          // Do stuff after the web browser completes. 
      }
      public void LoadWebPage()
      {
          webBrowser.Navigate(new Uri(url));
          webBrowser.DocumentCompleted = (s, e) => { _resetEvent.Set(); };
      }
