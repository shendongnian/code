        EventWaitHandle m_WaitHandle;
        
        public bool AddAllPhoto()
        {
          var amount = App.ViewModel.NewPictures.Count;
        if (m_WaitHandle!=null)
                    m_WaitHandle.Reset();
          for (int i = 0; i < amount; i++)
          {
        {
                        SavePicture(App.ViewModel.NewPictures[i]);
                        ThreadPool.QueueUserWorkItem((obj) =>
            {
                var index = (int)obj;
                DownloadPictureThumb(App.ViewModel.NewPictures[index].ID.ToString());
                DownloadPicture(App.ViewModel.NewPictures[index].ID.ToString());
        
            },i);
                  if (m_WaitHandle != null) m_WaitHandle.WaitOne();
                    }
        
                    return true;
                }
    
    public void DownloadPictureThumb(string path)
                {
                    string outputString = String.Format("http://" + App.ServerAdress + "/Pictures/Thumbs/{0}.jpg", path);
                    var client = new WebClient();
                    client.OpenReadCompleted += ClientOpenReadCompleted2;
                    client.OpenReadAsync(new Uri(outputString),path);
                }
        
                private static void ClientOpenReadCompleted2(object sender, OpenReadCompletedEventArgs e)
                {
                    var resInfo = new StreamResourceInfo(e.Result, null);
                    var reader = new StreamReader(resInfo.Stream);
        
                    byte[] contents;
                    using (var bReader = new BinaryReader(reader.BaseStream))
                    {
                        contents = bReader.ReadBytes((int)reader.BaseStream.Length);
                    }
        
                    var file = IsolatedStorageFile.GetUserStoreForApplication();
        
                    var thumbFilePath = String.Format(PicturesThumbsColectionKey + "{0}", e.UserState as string);
        
                    var stream = file.CreateFile(thumbFilePath);
        
                    stream.Write(contents, 0, contents.Length);
                    stream.Close();
                }
             
    public void DownloadPicture(string path)
                {
                    string outputString = String.Format("http://" + App.ServerAdress + "/Pictures/{0}.jpg", path);
                    var client = new WebClient();
                    client.OpenReadCompleted += ClientOpenReadCompleted1;
                    client.OpenReadAsync(new Uri(outputString), path);
                }
        
                private static void ClientOpenReadCompleted1(object sender, OpenReadCompletedEventArgs e)
                {
                    var resInfo = new StreamResourceInfo(e.Result, null);
                    var reader = new StreamReader(resInfo.Stream);
        
                    byte[] contents;
                    using (var bReader = new BinaryReader(reader.BaseStream))
                    {
                        contents = bReader.ReadBytes((int)reader.BaseStream.Length);
                    }
        
                    var file = IsolatedStorageFile.GetUserStoreForApplication();
        
                    var stream = file.CreateFile(e.UserState as string);
        
        
                    stream.Write(contents, 0, contents.Length);
                    stream.Close();
                  }
    
    [Here][1] you will find explanation to how to get the url from WebClient in OpenReadCompleted?
