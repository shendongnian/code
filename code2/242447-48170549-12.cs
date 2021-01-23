    /// <summary>Loads an image from bytes without leaving open a MemoryStream.</summary>
    /// <param name="fileData">Byte array containing the image to load.</param>
    /// <returns>The image</returns>
    public static Bitmap LoadImageSafe(Byte[] fileData)
    {
        using (MemoryStream stream = new MemoryStream(fileData))
        using (Bitmap sourceImage = new Bitmap(stream))    {
        {
            return CloneImage(sourceImage);
        }
    }
