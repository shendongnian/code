     //inside the button click event create a background worker
     BackgroundWorker worker = new BackgroundWorker();
     worker.RunWorkerCompleted += new 
    
     RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
     worker.DoWork += new DoWorkEventHandler(worker_DoWork);
     worker.RunWorkerAsync();
  
     Button btn_Pressed = (Button)sender;
     ImageBrush br = new ImageBrush();
     br.ImageSource = new BitmapImage(new Uri("/images/cat.png", UriKind.Relative));
     btn_Pressed.Background = br;
                
        
     public static void worker_RunWorkerCompleted(object sender, 
                                                  RunWorkerCompletedEventArgs e)
        {
        //once backgroudn work i.e. DoWork is complete this method will be 
        //called and code below will execute in UI thread
        SolidColorBrush sBrush = new SolidColorBrush(); 
        sBrush.Color = System.Windows.Media.Colors.White;
        btn_Pressed.Background = sBrush;  
        }
     public  static  void worker_DoWork(object sender, DoWorkEventArgs e)
        {
        //it will wait 5 secs in the background thread
        Thread.Sleep(5000);
        }
