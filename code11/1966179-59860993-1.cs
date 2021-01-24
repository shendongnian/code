    using (ApplicationContext db = new ApplicationContext())
    {
        List<ImageData> images = new List<ImageData>();
        foreach(var file in files)
        {        
            Image img = Image.FromFile(file);
            var imgRes = ResizeImage(img, ImageSettings.Width, ImageSettings.Height);
            MemoryStream memoryStream = new MemoryStream();
            img.Save(memoryStream, ImageFormat.Png);
            var label = Directory.GetParent(file).Name;
            var bytes = memoryStream.ToArray();
            images.Add(new ImageData { Image = bytes, Label = label });
            memoryStream.Close();
            img.Dispose();
            memoryStream.Dispose();
            imgRes.Dispose();
        }
        db.BulkInsert(images );
    }
