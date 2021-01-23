        public void GetXMLFile(string path)
        {
            WebClient wcXML = new WebClient();
            wcXML.OpenReadAsync(new Uri(path));
            wcXML.OpenReadCompleted += new OpenReadCompletedEventHandler(wc);
            
        }
        void wc(object sender, OpenReadCompletedEventArgs e)
        {
            var isolatedfile = IsolatedStorageFile.GetUserStoreForApplication();
            using (IsolatedStorageFileStream stream = new IsolatedStorageFileStream(iso_path, System.IO.FileMode.Create, isolatedfile))
            {
                byte[] buffer = new byte[e.Result.Length];
                while (e.Result.Read(buffer, 0, buffer.Length) > 0)
                {
                    stream.Write(buffer, 0, buffer.Length);
                }
                stream.Flush();
                System.Threading.Thread.Sleep(0);
            }            
        }
       
