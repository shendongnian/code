    var path = Path.GetFullPath("07T0L.jpg");
    string directory = Path.GetDirectoryName(path);
    var splitInto = 3;
    using (var img = Image.FromFile(path))
    using (var originalImage = new Bitmap(img))
    {
        for (int i = 0; i < splitInto; i++)
        {
            var rect = new Rectangle(0, originalImage.Height / splitInto * i, originalImage.Width, originalImage.Height / splitInto);
            using (var clonedImage = originalImage.Clone(rect, originalImage.PixelFormat))
                clonedImage.Save(directory + $"\\PageImage{i+1}.jpg");
        }
    }
