    private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      myWindow.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate() 
         {
            this.CurrentImage = (TransformedBitmap)e.Result;
            ....
         });
    }
