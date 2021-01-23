    static void Main(string[] args)
    {
        foreach (var file in Directory.GetFiles("C:\\MyImages", "*.jpg"))
        {
            // Spawn threads.
            new Action<string, float>(ResizeImage).BeginInvoke(file, 0.1f, null, null);
        }
        Console.ReadLine();
    }
    public static void ResizeImage(string filename, float scale)
    {
        using (var bitmap = Image.FromFile(filename))
        using (var resized = ResizeBitmap(bitmap, 0.1f, InterpolationMode.HighQualityBicubic))
        {
            var newFile = Path.ChangeExtension(filename, ".thumbnail" + Path.GetExtension(filename));
            if (File.Exists(newFile))
                File.Delete(newFile);
            resized.Save(newFile);
        }
    }
    public static Bitmap ResizeBitmap(Image source, float scale, InterpolationMode quality)
    {
        if (source == null)
            throw new ArgumentNullException("source");
        // Figure out the new size.
        var width = (int)(source.Width * scale);
        var height = (int)(source.Height * scale);
        // Create the new bitmap.
        // Note that Bitmap has a resize constructor, but you can't control the quality.
        var bmp = new Bitmap(width, height);
        using (var g = Graphics.FromImage(bmp))
        {
            g.InterpolationMode = quality;
            g.DrawImage(source, new Rectangle(0, 0, width, height));
            g.Save();
        }
        return bmp;
    }
