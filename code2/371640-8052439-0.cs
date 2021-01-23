    m_waitHandle.Reset(); // Make sure the wait handle blocks when WaitOne() is called
    for (int i = 0; i < amount; i++) 
    {
        // Process on a background thread
        ThreadPool.QueueUserWorkItem((obj) =>
        {
            //to add picture to DB   
            SavePicture(App.ViewModel.NewPictures[i]); 
 
            DownloadPicture(NewPictures[i].ID.ToString()); 
            DownloadPictureThumb(NewPictures[i].ID.ToString()));
        });
        m_waitHandle.WaitOne(); // Wait for processing to finish
    } 
