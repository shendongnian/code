     public void StartDownloading()
     {
            foreach(WebDownloader wd in singleAbLoader)
            {
                 wd.Start();
            }
     }
