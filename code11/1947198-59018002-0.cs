    public static void convertToFormat(string filename)
    {
        using (var image = Image.FromFile(@filename))
        {
            using (var bitmap = ResizeImage(image, Globals.ImageSize, Globals.ImageSize))
            {
                bitmap.Save(Globals.PRED_PATH, ImageFormat.Jpeg);
            }
        }
    }
    public static string ConvertImageToBase64String()
    {
        using (var image = Image.FromFile(Globals.PRED_PATH))
        {
            using (var imageStream = new MemoryStream())
            {
                image.Save(imageStream, ImageFormat.Jpeg);
                imageStream.Position = 0;
                var imageBytes = imageStream.ToArray();
                return Convert.ToBase64String(imageBytes);
            }
        }
    }
