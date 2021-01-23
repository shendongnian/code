    worker.DoWork += delegate(object s, DoWorkEventArgs args)
    {
       args.Result = lwrap.engine2(BitmapFrame.Create(MyPrj.App.draggedImage));
    };
    
    worker.RunWorkerCompleted += delegate(object s, RunWorkerCompletedEventArgs args)
    {
      if (args.Error != null)
      { ... }  // handle error
      else if (args.Cancelled)
      { ... } // handle Cancel
      else
      {
        imageViewer.CurrentImage = args.Result;
      }
      pd.Close();
    }
