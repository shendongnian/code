    private AutoResetEvent _finishAddPicsNotifier = new AutoResetEvent(false);
    
    private void OnMyButton_Click(object sender, EventArgs e)
    {
        //.....
        new Thread(AddPics)
        {
            Priority = ThreadPriority.Highest,
            IsBackground = true, //will explaine later
        }.Start();
        
        _finishAddPicsNotifier.WaitOne();//this will block until receive a signal to proceed
        execute();//this method will only called if the AddPics method finished
        /.....
    }
    
    private void AddPics()
    {
        //.......
         
        _finishAddPicsNotifier.Set();//when finish the adding the pictures allow the waiting method to proceed
    }
