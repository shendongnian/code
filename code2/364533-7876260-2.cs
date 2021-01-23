         public BitmapImage GetImage(string imagePath)
        {
            var image = new BitmapImage();
            imagePath = "/Glossy" + imagePath;
            using (var storage = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (storage.FileExists(imagePath))
                {
                    using (Stream stream = storage.OpenFile(imagePath, FileMode.Open, FileAccess.Read))
                    {                       
                        image.SetSource(stream);                        
                    }
                }
            }
            return image;
        }
