    Bitmap GetThumbnail(string path)
    {
        using (Image image = Image.FromFile(path))
        {
            return (Bitmap)image.GetThumbnailImage(32, 32, null, new IntPtr());
        }
    }
    // ...
    using (Bitmap bitmap = GetThumbnail(path))
    {
        //use bitmap
    }
