     //create background worker
     BackgroundWorker worker = new BackgroundWorker();
     //assign it work
     worker.DoWork += new DoWorkEventHandler(worker_DoWork);
     //start work
     worker.RunWorkerAsync();
                
            
    //this work will be done in background
    void worker_DoWork(object sender, DoWorkEventArgs e)
    {
        SET initial = 0;
        SET maxData = 1000
        DO UNTIL initial <1000
       CREATE db query "INSERT INTO (col1,col2,col3) VALUES(value1,value2,value3);"
       
       //in between your work do this to update label
       label.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal,new Action(delegate()
            {
             Label.Content = "SomeValue";
            }
            ));
       END DO
      }
     
