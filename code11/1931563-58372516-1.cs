    Stream stream = file.OpenReadStream();
    Image newImage = GetReducedImage(200, 200, stream);
                
    newImage.Save(filePath2);
    public Image GetReducedImage(int width, int height, Stream resourceImage)
        {
            try
            {
                Image image = Image.FromStream(resourceImage);
                Image thumb = image.GetThumbnailImage(width, height, () => false, IntPtr.Zero);
                return thumb;
            }
            catch (Exception e)
            {
                return null;
            }
        }
