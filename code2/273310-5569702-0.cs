    BackgroundWorker bg = new BackgroundWorker();
    object o;
    bg.DoWork += (c1,c2) =>
    {         
            Thread.Sleep(2000);        
            throw new IndexOutOfRangeException();
    };
    
    bg.RunWorkerCompleted += (c3,c4) => 
    {
     if (((RunWorkerCompletedEventArgs)e).Error != null)
        {
            MessageBox.Show(((RunWorkerCompletedEventArgs)e).Error.Message);
        }
    };
