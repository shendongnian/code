    //here progress bar is a UIElement
    progressBar.Dispatcher.BeginInvoke(
               System.Windows.Threading.DispatcherPriority.Normal
               , new DispatcherOperationCallback(delegate
                       {
                           progressBar1.Value = progressBar1.Value + 1;
                           //do what you need to do on UI Thread
                           return null;
                       }), null);
