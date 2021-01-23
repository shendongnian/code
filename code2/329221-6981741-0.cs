    public ImageSource imageSource
    {
        get
        {
                var Img = new BitmapImage();
                Img.BeginInit();
                Img.StreamSource = new System.IO.MemoryStream((byte[])Image);
                Img.EndInit();
                return Img;
         }
     }
