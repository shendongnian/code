    /// <summary>Loads an image without locking the underlying file.</summary>
    /// <param name="path">Path of the image to load</param>
    /// <returns>The image</returns>
    public static Bitmap LoadImageSafe(String path)
    {
        using (Bitmap sourceImage = new Bitmap(path))
        {
            return CloneImage(sourceImage);
        }
    }
