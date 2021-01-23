    public void Drop(DragEventArgs args)
    {
      string fileName = IsSingleTextFile(args);
      if (fileName == null) return;
      // It is better to create worker after check for file name.
      BackgroundWorker worker = new BackgroundWorker();
      worker.DoWork += (o, ea) =>
      {
        try
        {
          string filecontent = ReadAllText(fileName);    
          ea.Result = fileContent;
        }
        catch (Exception)
        {
          throw;
        }
      };
    
      worker.RunWorkerCompleted += (o, ea) =>
      {
        var fileContent = ea.Result as string;
        Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background,
            new Action(() => SfmLogFile = filecontent));
        // if IsBusy propery is not on the UI thread, then you may leave it here
        // otherwise it should be set using the dispatcher too.
        IsBusy = false;
      };
    
      IsBusy = true;
      worker.RunWorkerAsync();
      // Mark the event as handled, so TextBox's native Drop handler is not called.    
      args.Handled = true;
    }
