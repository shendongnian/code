    folderPathList.ToList().ForEach(p =>
            {
                ThreadPool.QueueUserWorkItem((o) =>
                     {
                         using (WebClient client = new WebClient())
                         {
                             client.Credentials = DefaultCredentials;
                             client.UploadString(p, "MKCOL", "");
                         }
                     });
            });
