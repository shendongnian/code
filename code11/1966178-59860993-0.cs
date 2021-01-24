    using (ApplicationContext db = new ApplicationContext())
    {
        foreach(var file in files)
        {        
            Image img = Image.FromFile(file);
            var imgRes = ResizeImage(img, ImageSettings.Width, ImageSettings.Height);
            MemoryStream memoryStream = new MemoryStream();
            img.Save(memoryStream, ImageFormat.Png);
            var label = Directory.GetParent(file).Name;
            var bytes = memoryStream.ToArray();
            memoryStream.Close();
            db.Add(new ImageData { Image = bytes, Label = label });
            img.Dispose();
            memoryStream.Dispose();
            imgRes.Dispose();
        }
    }
    
