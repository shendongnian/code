    m_waitHandle.Reset(); // Make sure the wait handle blocks when WaitOne() is called
    for (int i = 0; i < amount; i++) 
    {
        // Process on a background thread
        ThreadPool.QueueUserWorkItem((obj) =>
        {
            // Get the current index. This is an anonymous method so if
            // we use 'i' directly we will not necessarily be using the
            // correct index. In our case the wait handle avoids this 
            // problem as the pictures are downloaded one after the other
            // but it's still good practise to NEVER use a loop variable in
            // an anonymous method.
            int index = (int)obj;
            //to add picture to DB   
            SavePicture(App.ViewModel.NewPictures[index]); 
 
            DownloadPicture(NewPictures[index].ID.ToString()); 
            DownloadPictureThumb(NewPictures[index].ID.ToString()));
        }, i);
        m_waitHandle.WaitOne(); // Wait for processing to finish
    } 
