    private readonly object _oneAddPicturesLocker = new object();
    private void OnMyButton_Click(object sender, EventArgs e)
    {
        //.....
        new Thread(AddPics)
        {
            Priority = ThreadPriority.Highest,
            IsBackground = true,
        }.Start();
    }
    
    private void AddPics()
    {
        if (Monitor.TryEnter(_oneAddPicturesLocker))
        {
            //we only can proceed if no other AddPics are running.
            try
            {
                //.....
                OnFinishAddingPictures();
            }
            finally
            {
                Monitor.Exit(_oneAddPicturesLocker);
            }
        }
    }
    
    private void OnFinishAddingPictures()
    {
        execute();
    }
