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
        //.....
        
        OnFinishAddingPictures();
    }
    
    private void OnFinishAddingPictures()
    {
        execute();
    }
