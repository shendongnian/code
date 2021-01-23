            public BitmapImage ConvertToImage(System.Data.Linq.Binary binary)
        {
            byte[] buffer = binary.ToArray();
            MemoryStream stream = new MemoryStream(buffer);
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.StreamSource = stream;
            image.EndInit();
            return image;
        }
