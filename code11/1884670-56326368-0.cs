    public void BackgroundWorker1DoWork(object sender, DoWorkEventArgs e)
    {
     //After some Work Done
         Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, new 
           ThreadStart(delegate
           {
                 Teste();
           }));
    }
   
