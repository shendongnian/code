    public Image ImageZoom(Image image, Size newSize)
        {
            var bitmap = new Bitmap(image, newSize.Width, newSize.Height);
            using (var g = Graphics.FromImage(bitmap))
            {
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            }
    
            return bitmap;
        }
