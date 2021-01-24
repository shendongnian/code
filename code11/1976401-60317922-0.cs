    void timer_Tick(object sender, EventArgs e)
        {
            var webClient = new WebClient();            
            var _image = new BitmapImage();
            using (var stream = new MemoryStream(webClient.DownloadData(@"http://0.0.0.0/api/camera/snapshot?width=640&height=480")))
            {
                _image.BeginInit();
                _image.CacheOption = BitmapCacheOption.OnLoad;
                _image.StreamSource = stream;
                _image.EndInit();
            }
            img.Source = _image;
        }
