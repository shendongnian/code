       _ms = new MemoryStream();
       thumbBitmap.Save(_ms, ImageFormat.Png);
       _ms.Position = 0;
       ImageLoaded = true;
        //thumb image property of this class, use in binding  
        public BitmapImage ThumbImage
        {
            get
            {
                if (_thumbImage == null && ImageLoaded)
                {
                    BitmapImage bi = new BitmapImage();
                    bi.BeginInit();
                    bi.StreamSource = _ms;
                    bi.EndInit();
                    _thumbImage = bi;
                }
                return _thumbImage;
            }
        }
