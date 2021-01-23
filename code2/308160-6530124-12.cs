    private AutoResetEvent _finishAddPicsNotifier = new AutoResetEvent(false);
    
    private void OnMyButton_Click(object sender, EventArgs e)
    {
        //.....
        new Thread(AddPics)
        {
            Priority = ThreadPriority.Highest,
            IsBackground = true, //will explain later
        }.Start();
        
        _finishAddPicsNotifier.WaitOne();//this will block until receive a signal to proceed
        execute();//this method will only be called after the AddPics method finished
        /.....
    }
    
    private void AddPics()
    {
        try{
            //.......
        }
        finally{
            _finishAddPicsNotifier.Set();//when finished adding the pictures, allow the waiting method to proceed
        }
    }
