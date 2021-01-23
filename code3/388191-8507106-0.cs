    worker.DoWork += delegate(object s, DoWorkEventArgs args)
    {
       e.Result = lwrap.engine2(BitmapFrame.Create(MyPrj.App.draggedImage));
    };
    
    worker.RunWorkerCompleted += delegate(object s, RunWorkerCompletedEventArgs args)
    {
      if (e.Error != null)
      { ... }  // handle error
      else if (e.Cancelled)
      { ... } // handle Cancel
      else
      {
        imageViewer.CurrentImage = e.Result;
      }
      pd.Close();
    }
