    public void changeDPI(String imagePathSource, String imagePathDestination, Single dpiX, Single dpiY)
    {
        using (Bitmap bitmap = new Bitmap(imagePathSource))
        {
            bitmap.SetResolution(dpiX, dpiY);
            bitmap.Save(imagePathDestination, bitmap.RawFormat);
        }
    }
