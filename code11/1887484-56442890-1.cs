    var path = Path.GetFullPath("07T0L.jpg");
    string directory = Path.GetDirectoryName(path);
    //optional: cleanup files from a previous run - incase the previous run splitted into 5 images and now we only produce 3, so that only 3 files will remain in the destination
    var oldFiles = Directory.EnumerateFiles(directory, "PageImage*.jpg");
    foreach (var oldFile in oldFiles)
        File.Delete(oldFile);
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
