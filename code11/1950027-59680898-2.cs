    public void changeDPI(String imagePathSource, String imagePathDestination, Single dpiX, Single dpiY)
    {
        Byte[] fileData = File.ReadAllbytes(imagePathSource);
        using (MemoryStream ms = new MemoryStream(fileData))
        using (Bitmap loadedImage = new Bitmap(ms))
        {
            bitmap.SetResolution(dpiX, dpiY);
            bitmap.Save(imagePathDestination, bitmap.RawFormat);
        }
    }
