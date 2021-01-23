    public static Lazy<ImageDrawing> LoadImage(string fileName)
    {
        return new Lazy<ImageDrawing>(() => {
            System.Drawing.Bitmap b = new System.Drawing.Bitmap(fileName);
            System.Drawing.Size s = b.Size;
            System.Windows.Media.ImageDrawing im = new System.Windows.Media.ImageDrawing();
            im.Rect = new System.Windows.Rect(0, 0, s.Width, s.Height);
            im.ImageSource = new System.Windows.Media.Imaging.BitmapImage(new Uri(fileName,     UriKind.Absolute));
            return im;
        });
    }
